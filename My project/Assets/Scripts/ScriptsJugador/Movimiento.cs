using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]

    [SerializeField] private PerfilJugador perfilJugador;
    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;
    private bool orientacionDer = true;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private BoxCollider2D miCollider2D;

    private int saltarMask;
    
    //private bool ladoIzq = false;
    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miCollider2D = GetComponent<BoxCollider2D>();
        saltarMask = LayerMask.GetMask("Plataformas");
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);
        int velocidadX = (int)miRigidbody2D.velocity.x;
        FlipHorizontal();
        gameObject.GetComponent<AnimacionesJugador>().AnimacionMovimientoJugador(velocidadX);
        gameObject.GetComponent<AnimacionesJugador>().AnimacionSaltoJugador(!EnContactoConPlataforma());
    }
    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * perfilJugador.Velocidad);
    }

    private bool EnContactoConPlataforma()
    {
        return miCollider2D.IsTouchingLayers(saltarMask);
    }

    private void FlipHorizontal()
    {
        if((orientacionDer == true && moverHorizontal < 0f) || (orientacionDer == false && moverHorizontal > 0f)) { 
            orientacionDer = !orientacionDer;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public Rigidbody2D GetBody()
    {
        return miRigidbody2D;
    }

    public void Rebotar(Vector2 puntoImpacto)
    {
        miRigidbody2D.velocity = new Vector2(-perfilJugador.VelocidadRebote.x * puntoImpacto.x, perfilJugador.VelocidadRebote.y);
    }
}
