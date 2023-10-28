using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlteracionesEstado : MonoBehaviour
{
    [SerializeField] private int duracionFuego;
    [SerializeField] private int dagno;
    [SerializeField] private int multiplicador;
    [SerializeField] private int duracionBaba;
    [SerializeField] private int reduccionBaba;
    [SerializeField] private int reduccionBabaJefe;
    [SerializeField] private int duracionHielo;
    [SerializeField] private int reduccionHielo;
    [SerializeField] private float reduccionHieloJefe;
    private SpriteRenderer miSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        miSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BolaDeBaba"))
        {
            Pegote();
        }

        if (collision.gameObject.CompareTag("BolaDeFuego"))
        {
            Incendio();
        }

        if (collision.gameObject.CompareTag("BolaDeHielo"))
        {
            Congelamiento();
        }
    }
    public void Incendio() 
    {
        StartCoroutine(Apagar());
        StartCoroutine(DagnarPorFuego());
    }
    public IEnumerator DagnarPorFuego()
    {
        
        for (int i = 0; i < duracionFuego; i++)
        {
            if (gameObject.CompareTag("Enemigos") || gameObject.CompareTag("EnemigosEnojados"))
            {
                
                yield return new WaitForSeconds(1);
                gameObject.GetComponent<Enemigo>().ModificarVidaEnemigo(dagno);               
            }

            if (gameObject.CompareTag("Jefe"))
            {
                yield return new WaitForSeconds(1);
                gameObject.GetComponent<Enemigo>().ModificarVidaEnemigo(multiplicador);
            }
        }
    }

    private IEnumerator Apagar()
    {
        miSpriteRenderer.color = Color.yellow;
        yield return new WaitForSeconds(duracionFuego);
        miSpriteRenderer.color = Color.white;
    }
    public void Pegote()
    {
        StartCoroutine(Despegar());
        StartCoroutine(ReducirDagnoDeAtaque());
    }

    public IEnumerator ReducirDagnoDeAtaque()
    {
        
        if(gameObject.CompareTag("Enemigos") || gameObject.CompareTag("EnemigosEnojados"))
        {
            
            gameObject.GetComponent<AtaqueRocoso>().ModificarDagnoAtaque(-reduccionBaba);
            yield return new WaitForSeconds(duracionBaba);
            gameObject.GetComponent<AtaqueRocoso>().ModificarDagnoAtaque(reduccionBaba);
            
        }

        if (gameObject.CompareTag("Jefe"))
        {
            gameObject.GetComponent<DagnoColision>().ModificarDagnoColision(-reduccionBabaJefe);
            yield return new WaitForSeconds(duracionBaba);
            gameObject.GetComponent<DagnoColision>().ModificarDagnoColision(reduccionBabaJefe);
            
        }
    }

    private IEnumerator Despegar()
    {
        miSpriteRenderer.color = Color.green;
        yield return new WaitForSeconds(duracionBaba);
        miSpriteRenderer.color = Color.white;
    }

    public void Congelamiento()
    {
        StartCoroutine(Descongelar());
        StartCoroutine(ReducirVelocidad());
    }

    public IEnumerator ReducirVelocidad()
    {
        
        if (gameObject.CompareTag("Enemigos") || gameObject.CompareTag("EnemigosEnojados"))
        {
            
            gameObject.GetComponent<MovimientoRocoso>().ModificarVelocidad(-reduccionHielo);
            yield return new WaitForSeconds(duracionHielo);
            gameObject.GetComponent<MovimientoRocoso>().RestaurarVelocidad();
            
        }

        if (gameObject.CompareTag("Jefe"))
        {
            gameObject.GetComponent<JefeRocoso>().ModificarVelocidadCorreteo(-reduccionHieloJefe);
            yield return new WaitForSeconds(duracionBaba);
            gameObject.GetComponent<JefeRocoso>().RestaurarVelocidadCorreteo();
            
        }
    }

    private IEnumerator Descongelar()
    {
        miSpriteRenderer.color = Color.blue;
        yield return new WaitForSeconds(duracionHielo);
        miSpriteRenderer.color = Color.white;
    }
}
