using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFuego : MonoBehaviour
{
    //[SerializeField] private int dagnoFuego;
    //[SerializeField] private int multiplicadorPorJefe;
    //[SerializeField] private int duracionFuego;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigos") || collision.gameObject.CompareTag("EnemigosEnojados"))
        {
            //collision.transform.GetComponent<Enemigo>().GetComponent<SpriteRenderer>().color = Color.yellow;
            //InvokeRepeating(nameof(DagnarPorFuego), 0, duracionFuego);
            //StartCoroutine(CambiarColorObjetivo(collision));
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Jefe"))
        {
            //collision.transform.GetComponent<Enemigo>().GetComponent<SpriteRenderer>().color = Color.yellow;
            //dagnoFuego *= multiplicadorPorJefe;
            //InvokeRepeating(nameof(DagnarPorFuego), 0, duracionFuego);
            //StartCoroutine(CambiarColorObjetivo(collision));
            Destroy(gameObject);
        }
    }

    //private void DagnarPorFuego(Collision2D collision)
    //{
    //    collision.transform.GetComponent<Enemigo>().ModificarVidaEnemigo(-dagnoFuego);

    //}

    //private IEnumerator CambiarColorObjetivo(Collision2D collision)
    //{
        
    //    yield return new WaitForSeconds(duracionFuego);
    //    collision.transform.GetComponent<Enemigo>().GetComponent<SpriteRenderer>().color = Color.white;
    //}
}
