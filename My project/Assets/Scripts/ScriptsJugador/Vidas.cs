using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]

    [SerializeField] private PerfilJugador perfilJugador;
    public void ModificarVida(float puntos)
    {
        perfilJugador.Vida += puntos;
        Debug.Log(EstasVivo());
    }


    private bool EstasVivo()
    {
        if (perfilJugador.Vida <= 0)
        {
            Debug.Log("PERDISTE");
        }
        return perfilJugador.Vida > 0;
    }
}
