using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueRocoso : MonoBehaviour
{
    public bool atacando;
    //private MovimientoRocoso vinculoMovimiento;
    [SerializeField] private float dagnoGolpe;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float intervaloEntreAtaques;
    [SerializeField] private Transform controladorGolpeEnemigo;
    //private Animator miAnimator;
    // Start is called before the first frame update
    void Start()
    {
        //miAnimator = GetComponent<Animator>();
        //vinculoMovimiento = GetComponent<MovimientoRocoso>();
        CausarDagno();
    }

    public void ModificarDagnoAtaque(float puntos)
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
                    //miAnimator.SetTrigger("Atacando");
                    //miAnimator.SetBool("Persiguiendo", false);
                    gameObject.GetComponent<EjecucionAnimaciones>().ActivarAnimacionAtaque();
                    atacando = true;
                }
                else
                {
                    atacando = false;
                    //miAnimator.SetBool("Persiguiendo", true);
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
