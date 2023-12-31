using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]

    [SerializeField] private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    [SerializeField] private UnityEvent<string> OnHealthChange;

    private Rigidbody2D rb;
    private Animator miAnimator;
    private void Start()
    {
        perfilJugador.Vida = perfilJugador.VidaMaxima;
        rb = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"), LayerMask.NameToLayer("Enemigos"), false);
        OnHealthChange.Invoke(GameManager.Instance.GetVidaSing().ToString());
    }
    public void ModificarVida(int puntos)
    {
        if (perfilJugador.Vida > 0)
        {
            perfilJugador.Vida += puntos;
            GameManager.Instance.ModificarVidaSing(puntos);
            //perfilJugador.Vida = GameManager.Instance.GetVidaSing();
            OnHealthChange.Invoke(GameManager.Instance.GetVidaSing().ToString());
        }
        if(perfilJugador.Vida <= 0)
        {
            perfilJugador.AtaqueHabilitado = false;
            OnHealthChange.Invoke(GameManager.Instance.GetVidaSing().ToString());
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            miAnimator.SetTrigger("Muerte");
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"), LayerMask.NameToLayer("Enemigos"), true);
        }
    }

    public void Morir()
    {
        Destroy(gameObject);
    }
}
