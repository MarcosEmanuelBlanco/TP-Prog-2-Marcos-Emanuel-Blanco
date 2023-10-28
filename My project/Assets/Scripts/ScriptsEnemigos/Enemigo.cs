using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    
    [SerializeField] private float vidaEnemigo;

    public int valorPorEliminacion = 1;

    

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
