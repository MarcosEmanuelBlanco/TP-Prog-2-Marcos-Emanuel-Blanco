using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueRocoso : MonoBehaviour
{
    public bool atacando;
    [SerializeField] private int dagnoGolpe;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float intervaloEntreAtaques;
    [SerializeField] private Transform controladorGolpeEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        CausarDagno();
    }

    public void ModificarDagnoAtaque(int puntos)
    {
        dagnoGolpe += puntos;
    }

    private void Cabezazo()
    {
        if(gameObject.GetComponent<MovimientoRocoso>().GetAturdimiento() == false) {
            Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpeEnemigo.position, radioAtaque);
            foreach (Collider2D col in objetos)
            {
                if (col.CompareTag("Player"))
                {
                    col.transform.GetComponent<Jugador>().ModificarVida(-dagnoGolpe);
                    gameObject.GetComponent<EjecucionAnimaciones>().ActivarAnimacionAtaque();
                    atacando = true;
                }
                else
                {
                    atacando = false;
                    gameObject.GetComponent<EjecucionAnimaciones>().ActivarAnimacionMovimiento();
                }
            }
        }
    }

    private void CausarDagno()
    {
        InvokeRepeating(nameof(Cabezazo), 0, intervaloEntreAtaques);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpeEnemigo.position, radioAtaque);
    }

    public bool GetAtacando()
    {
        return atacando;
    }
}
