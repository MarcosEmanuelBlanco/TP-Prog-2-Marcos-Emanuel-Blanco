using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeHielo : MonoBehaviour
{
    //[SerializeField] private int reduccionPorHielo;
    //[SerializeField] private int multiplicadorPorJefe;
    //[SerializeField] private int duracionHielo;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigos") || collision.gameObject.CompareTag("EnemigosEnojados"))
        {
            //collision.transform.GetComponent<Enemigo>().GetComponent<SpriteRenderer>().color = Color.blue;
            //StartCoroutine(HieloEnObjetivo(collision));
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Jefe"))
        {
            //collision.transform.GetComponent<Enemigo>().GetComponent<SpriteRenderer>().color = Color.blue;
            //StartCoroutine(HieloEnJefe(collision));
            Destroy(gameObject);
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
