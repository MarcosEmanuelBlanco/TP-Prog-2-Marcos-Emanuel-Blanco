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

    public bool GetActive()
    {
        return gameObject.activeInHierarchy;
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
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if(jugador.GetComponent<Progresion>() != null)
        {
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
        }
        
}
