using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "SO/Perfil Jugador")]
public class PerfilJugador : ScriptableObject
{
    [Header("Configuracion Vida")]
    [SerializeField] private int vida;
    public int Vida { get => vida; set => vida = value;}

    [SerializeField] private int vidaMaxima;
    public int VidaMaxima { get => vidaMaxima; set => vidaMaxima = value; }

    [Header("Configuracion Movimiento")]
    [SerializeField] float velocidad = 5f;
    public float Velocidad { get => velocidad; set => velocidad = value;}

    [SerializeField] private float fuerzaSalto = 5f;
    public float FuerzaSalto { get => fuerzaSalto; set => fuerzaSalto = value;}

    [SerializeField] private Vector2 velocidadRebote;

    public Vector2 VelocidadRebote { get => velocidadRebote; set => velocidadRebote = value; }

    [Header("Configuracion Sonidos")]
    [SerializeField] private AudioClip jumpSFX;
    public AudioClip JumpSFX { get => jumpSFX; set => jumpSFX = value;}

    [SerializeField] private AudioClip collisionSFX;
    public AudioClip CollisionSFX { get => collisionSFX; set => collisionSFX = value;}

    [Header("Configuracion Ataque")]
    [SerializeField] private float radioGolpe;
    public float RadioGolpe { get => radioGolpe; set => radioGolpe = value;}

    [SerializeField] private float dagnoGolpe;
    public float DagnoGolpe { get => dagnoGolpe; set => dagnoGolpe = value;}

    [SerializeField] private float intervaloEntreGolpes;
    public float IntervaloEntreGolpes {  get => intervaloEntreGolpes; set => intervaloEntreGolpes = value;}

    [SerializeField] private float esperaSiguienteAtaque;
    public float EsperaSiguienteAtaque { get => esperaSiguienteAtaque; set => esperaSiguienteAtaque = value;  }

    [SerializeField] private bool ataqueHabilitado = true;

    public bool AtaqueHabilitado { get => ataqueHabilitado; set => ataqueHabilitado = value;}

    [Header("Configuracion Orden de Misiones")]
    
    public int rocososComunesEliminados = 0;
    public int RocososComunesEliminados { get => rocososComunesEliminados; set => rocososComunesEliminados = value; }
    
    public int rocososEnojadosEliminados = 0;

    public int RocososEnojadosEliminados { get => rocososEnojadosEliminados; set => rocososEnojadosEliminados = value; }

    public int granRocosoEliminado = 0;
    public int GranRocosoEliminado { get => granRocosoEliminado; set => granRocosoEliminado = value; }

    [SerializeField] private int totalRocososComunes;

    public int TotalRocososComunes {  get => totalRocososComunes; set => totalRocososComunes = value;}

    [SerializeField] private int totalRocososEnojados;

    public int TotalRocososEnojados { get => totalRocososEnojados; set => totalRocososEnojados = value; }

    public int valorReinicioRocososComunes = 0;
    public int ValorReinicioRocososComunes { get => valorReinicioRocososComunes; set => valorReinicioRocososComunes = value; }

    public int valorReinicioRocososEnojados = 0;

    public int ValorReinicioRocososEnojados { get => valorReinicioRocososEnojados; set => valorReinicioRocososEnojados = value; }

    public int valorReinicioGranRocoso = 0;
    public int ValorReinicioGranRocoso { get => valorReinicioGranRocoso; set => valorReinicioGranRocoso = value; }


}
