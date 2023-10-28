using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFuego : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigos") || collision.gameObject.CompareTag("EnemigosEnojados") || collision.gameObject.CompareTag("Jefe"))
        {
            //collision.transform.GetComponent<AlteracionesEstado>().Incendio(dagno,multiplicador);
            //collision.transform.GetComponent<AlteracionesEstado>().ColorFuego();
            //collision.transform.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.SetActive(false);
        }
    }
}
