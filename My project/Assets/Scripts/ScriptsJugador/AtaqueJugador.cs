using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    [SerializeField] private Transform posicionControladorGolpe;
    [SerializeField] private PerfilJugador perfilJugador;
    private int VersionAnimacion;
    private void Start()
    {
        perfilJugador.AtaqueHabilitado = true;
    }
    private void Update()
    {
        if(perfilJugador.AtaqueHabilitado)
        {
            if (perfilJugador.EsperaSiguienteAtaque > 0)
            {
                perfilJugador.EsperaSiguienteAtaque -= Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.C) && Input.GetAxis("Horizontal") == 0 && perfilJugador.EsperaSiguienteAtaque <= 0)
            {
                Golpe();
                perfilJugador.EsperaSiguienteAtaque = perfilJugador.IntervaloEntreGolpes;
            }
        }
    }
    private void Golpe()
    {
        gameObject.GetComponent<AnimacionesJugador>().AnimacionAtaqueJugador();
     
        Collider2D[] objetos = Physics2D.OverlapCircleAll(posicionControladorGolpe.position, perfilJugador.RadioGolpe);
        foreach (Collider2D col in objetos)
        {
            if (col.CompareTag("Enemigos") || col.CompareTag("EnemigosEnojados") || col.CompareTag("Jefe"))
            {
                col.transform.GetComponent<Enemigo>().ModificarVidaEnemigo(-perfilJugador.DagnoGolpe);
            }

            if (col.CompareTag("Enemigos") || col.CompareTag("EnemigosEnojados"))
            {
                StartCoroutine(col.transform.GetComponent<MovimientoRocoso>().Aturdirse());
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(posicionControladorGolpe.position, perfilJugador.RadioGolpe);
    }
}
