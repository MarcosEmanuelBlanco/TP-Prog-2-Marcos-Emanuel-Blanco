using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeBaba : MonoBehaviour
{
    //[SerializeField] private int reduccionPorPegote;
    //[SerializeField] private int multiplicadorPorJefe;
    //[SerializeField] private int duracionPegote;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigos") || collision.gameObject.CompareTag("EnemigosEnojados"))
        {
            //collision.transform.GetComponent<Enemigo>().GetComponent<SpriteRenderer>().color = Color.green;
            //StartCoroutine(PegoteEnObjetivo(collision));
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Jefe"))
        {
            //collision.transform.GetComponent<Enemigo>().GetComponent<SpriteRenderer>().color = Color.green;
            //reduccionPorPegote *= multiplicadorPorJefe;
            //StartCoroutine(PegoteEnObjetivo(collision));
            Destroy(gameObject);
        }
    }

    //private IEnumerator PegoteEnObjetivo(Collision2D collision)
    //{
        
    //    collision.transform.GetComponent<AtaqueRocoso>().ModificarDagnoAtaque(-reduccionPorPegote);
    //    yield return new WaitForSeconds(duracionPegote);
    //    collision.transform.GetComponent<Enemigo>().GetComponent<SpriteRenderer>().color = Color.white;
    //    collision.transform.GetComponent<AtaqueRocoso>().ModificarDagnoAtaque(+reduccionPorPegote);
    //}
}
