using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagnoColision : MonoBehaviour
{
    [SerializeField] private int dagnoColision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            jugador.ModificarVida(-dagnoColision);
            Debug.Log(" PUNTOS DE DAÑO REALIZADOS AL JUGADOR " + dagnoColision);
        }
    }

    public void ModificarDagnoColision(int puntos)
    {
        dagnoColision += puntos;
    }
}
