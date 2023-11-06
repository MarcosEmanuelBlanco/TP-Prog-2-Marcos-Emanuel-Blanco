using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Progresion : MonoBehaviour
{
    private Stack<string> ordenMisiones;
    [SerializeField] private PerfilJugador perfilJugador;
    [SerializeField] private UnityEvent<string> OnAngryRockKillProgress;
    [SerializeField] private UnityEvent<string> OnCalmRockKillProgress;
    [SerializeField] private UnityEvent<string> OnBigRockKillProgress;
    // Start is called before the first frame update
    void Start()
    {
        OnAngryRockKillProgress.Invoke(perfilJugador.RocososEnojadosEliminados.ToString()/*GameManager.Instance.GetRocE().ToString()*/);
        OnCalmRockKillProgress.Invoke(perfilJugador.RocososComunesEliminados.ToString()/*GameManager.Instance.GetRocC().ToString()*/);
        OnBigRockKillProgress.Invoke(perfilJugador.GranRocosoEliminado.ToString()/*GameManager.Instance.GetGranRoc().ToString()*/);
        ordenMisiones = new Stack<string>();
        ordenMisiones.Push("El Gran Pétreo se ha ido. Eso debería sanarlos a todos...");
        ordenMisiones.Push("Los pétreos sanos también deben detenerse, no sería bueno que aniquilen a sus hermanos.");
        ordenMisiones.Push("Algunos pétreos menores han sido envenenados y están furiosos, volviéndose más fuertes. Deben ser detenidos antes que nada.");
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
        //GameManager.Instance.ModificarRocE(valorUnidad);
        OnAngryRockKillProgress.Invoke(perfilJugador.RocososEnojadosEliminados.ToString());
    }

    public void EliminarRocosoComun(int valorUnidad)
    {
        perfilJugador.RocososComunesEliminados += valorUnidad;
        //GameManager.Instance.ModificarRocC(valorUnidad);
        OnCalmRockKillProgress.Invoke(perfilJugador.RocososComunesEliminados.ToString());
    }

    public void EliminarGranRocoso(int valorUnidad)
    {
        perfilJugador.GranRocosoEliminado += valorUnidad;
        //GameManager.Instance.ModificarGranRoc(valorUnidad);
        OnBigRockKillProgress.Invoke(perfilJugador.GranRocosoEliminado.ToString());
    }
}
