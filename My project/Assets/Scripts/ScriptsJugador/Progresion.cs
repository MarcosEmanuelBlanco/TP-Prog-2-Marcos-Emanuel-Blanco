using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progresion : MonoBehaviour
{
    private Stack<string> ordenMisiones;
    [SerializeField] private PerfilJugador perfilJugador;
    // Start is called before the first frame update
    void Start()
    {
        ordenMisiones = new Stack<string>();
        ordenMisiones.Push("El Gran P�treo se ha ido. Eso deber�a sanarlos a todos...");
        ordenMisiones.Push("Los p�treos sanos tambi�n deben detenerse, no ser�a bueno que aniquilen a sus hermanos.");
        ordenMisiones.Push("Algunos p�treos menores han sido envenenados y est�n furiosos, volvi�ndose m�s fuertes. Deben ser detenidos antes que nada.");
    }

    // Update is called once per frame
    void Update()
    {
        if (perfilJugador.RocososEnojadosEliminados == perfilJugador.TotalRocososEnojados && ordenMisiones.Count == 3)
        {
            Debug.Log("Etapa completada: " + ordenMisiones.Pop());
        }

        if (perfilJugador.RocososComunesEliminados == perfilJugador.TotalRocososComunes && ordenMisiones.Count == 2)
        {
            Debug.Log("Etapa completada: " + ordenMisiones.Pop());
        }

        if (perfilJugador.GranRocosoEliminado == 1 && ordenMisiones.Count == 1)
        {
            Debug.Log("Etapa completada: " + ordenMisiones.Pop());
            Debug.Log("Conflicto detenido");
        }
    }

    public void EliminarRocosoEnojado(int valorUnidad)
    {
        perfilJugador.RocososEnojadosEliminados += valorUnidad;
    }

    public void EliminarRocosoComun(int valorUnidad)
    {
        perfilJugador.RocososComunesEliminados += valorUnidad;
    }

    public void EliminarGranRocoso(int valorUnidad)
    {
        perfilJugador.GranRocosoEliminado += valorUnidad;
    }
}
