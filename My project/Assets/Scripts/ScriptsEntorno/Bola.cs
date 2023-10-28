using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigos") || collision.gameObject.CompareTag("EnemigosEnojados") || collision.gameObject.CompareTag("Jefe"))
        {
            gameObject.SetActive(false);
        }
    }
}
