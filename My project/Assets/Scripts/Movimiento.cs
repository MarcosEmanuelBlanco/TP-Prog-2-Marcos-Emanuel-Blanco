using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;

    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;
    private bool orientacionDer = true;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;
    private BoxCollider2D miCollider2D;

    private int saltarMask;
    
    //private bool ladoIzq = false;
    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
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
        miAnimator.SetInteger("Velocidad", velocidadX);
        miAnimator.SetBool("EnAire", !EnContactoConPlataforma());
    }
    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * velocidad);
    }

    private bool EnContactoConPlataforma()
    {
        return miCollider2D.IsTouchingLayers(saltarMask);
    }

    private void FlipHorizontal()
    {
        if((orientacionDer == true && moverHorizontal < 0f) || (orientacionDer == false && moverHorizontal > 0f)) { 
            orientacionDer = !orientacionDer;
            miSprite.flipX = !miSprite.flipX;
        }
    }
}
