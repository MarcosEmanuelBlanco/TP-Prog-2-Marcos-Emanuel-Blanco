using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeHielo : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigos") || collision.gameObject.CompareTag("EnemigosEnojados") || collision.gameObject.CompareTag("Jefe"))
        {
            //collision.transform.GetComponent<AlteracionesEstado>().Congelamiento(reduccionHielo, reduccionHieloJefe);
            //collision.transform.GetComponent<AlteracionesEstado>().ColorHielo();
            gameObject.SetActive(false);
        }
    }

    //private IEnumerator HieloEnObjetivo(Collision2D collision)
    //{
        
    //    collision.transform.GetComponent<MovimientoRocoso>().ModificarVelocidad(reduccionPorHielo);
    //    yield return new WaitForSeconds(duracionHielo);
    //    collision.transform.GetComponent<Enemigo>().GetComponent<SpriteRenderer>().color = Color.white;
    //    collision.transform.GetComponent<MovimientoRocoso>().ModificarVelocidad(-reduccionPorHielo);
    //}

    //private IEnumerator HieloEnJefe(Collision2D collision)
    //{
    //    collision.transform.GetComponent<Enemigo>().GetComponent<SpriteRenderer>().color = Color.blue;
    //    collision.transform.GetComponent<JefeRocoso>().ModificarVelocidadCorreteo(-reduccionPorHielo);
    //    yield return new WaitForSeconds(duracionHielo);
    //    collision.transform.GetComponent<Enemigo>().GetComponent<SpriteRenderer>().color = Color.white;
    //    collision.transform.GetComponent<JefeRocoso>().ModificarVelocidadCorreteo(reduccionPorHielo);
    //}
}
