using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] private float puntos = 5f;
    [SerializeField] private float vidaEnemigo;
    private SpriteRenderer miSpriteRenderer;
    public int valorPorEliminacion = 1;

    private void OnEnable()
    {
        miSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            jugador.ModificarVida(-puntos);
            Debug.Log(" PUNTOS DE DAÑO REALIZADOS AL JUGADOR " + puntos);
        }
    }

    public void ModificarVidaEnemigo(float puntos)
    {
        vidaEnemigo += puntos;
        Debug.Log("Enemigo herido");
        Muerte();
    }

    private void Muerte()
    {
        if (vidaEnemigo <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        Progresion progresion = jugador.GetComponent<Progresion>();
        if (gameObject.CompareTag("Enemigos"))
        {
            progresion.EliminarRocosoComun(valorPorEliminacion);
        }

        if (gameObject.CompareTag("EnemigosEnojados"))
        {
            progresion.EliminarRocosoEnojado(valorPorEliminacion);
        }

        if (gameObject.CompareTag("Jefe"))
        {
            progresion.EliminarGranRocoso(valorPorEliminacion);
        }
    }
}
