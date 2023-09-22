using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeRocoso : MonoBehaviour
{
    [SerializeField] float tiempoEntreDisparos;
    [SerializeField] float tiempoEntreSaltos;
    [SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] float tiempoEntreCorreteos;
    [SerializeField] float tiempoDeCarga; //Variable que se usa para demorar el disparo y ejecutar una animación (no implementada aún).
    [SerializeField] float duracionDeCorreteo;
    [SerializeField] float velocidadCorreteo;
    [SerializeField] float divisorDuracionDeCorreteo;

    [SerializeField] GameObject[] orbesRojas;
    [SerializeField] Transform[] puntoDisparoBola;

    private Rigidbody2D miRigidbody2D;
    private SpriteRenderer miSprite;

    private float tiempoActualEspera;
    private int estadoActual;

    private const int Disparo = 0;
    private const int Salto = 1;
    private const int Correteo = 2;
    // Start is called before the first frame update
    void Start()
    {
        estadoActual = Disparo;
        StartCoroutine(ComportamientoJefe());
    }
    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miSprite = GetComponent<SpriteRenderer>();
    }
    private IEnumerator ComportamientoJefe()
    {
        while (true)
        {
            switch(estadoActual)
            {
                case Disparo:
                    StartCoroutine(Disparar());
                    tiempoActualEspera = tiempoEntreDisparos;
                    break;
                case Salto:
                    StartCoroutine(Saltar());
                    tiempoActualEspera = tiempoEntreSaltos;
                    break;
                case Correteo:
                    StartCoroutine(Corretear());
                    tiempoActualEspera = tiempoEntreCorreteos;
                    break;
            }
            Debug.Log(estadoActual);
            yield return new WaitForSeconds(tiempoActualEspera);
            ActualizarEstado();
        }
    }

    private IEnumerator Disparar()
    {
        yield return new WaitForSeconds(tiempoDeCarga);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(orbesRojas[i], puntoDisparoBola[i].position, Quaternion.identity);
        }
    }

    private IEnumerator Saltar()
    {
        miRigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse); //Más adelante se pondrá aquí una función para que cree un área de daño al tocar el piso.
        yield return null;
    }

    private IEnumerator Corretear() //Aquí causará empuje al colisionar con el jugador.
    {
        float tiempoInicio = Time.time;
        Vector2 posicionInicial = transform.position;
        Vector2 posicionObjetivo = new Vector2(transform.position.x + velocidadCorreteo, transform.position.y);

        while (Time.time < tiempoInicio + duracionDeCorreteo / divisorDuracionDeCorreteo)
        {
            transform.position = Vector2.Lerp(posicionInicial, posicionObjetivo, (Time.time - tiempoInicio) / (duracionDeCorreteo / divisorDuracionDeCorreteo));
            yield return null;
        }
        miSprite.flipX = !miSprite.flipX;    
        // Mover hacia atrás (retroceso)
        tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + duracionDeCorreteo / divisorDuracionDeCorreteo)
        {
            transform.position = Vector2.Lerp(posicionObjetivo, posicionInicial, (Time.time - tiempoInicio) / (duracionDeCorreteo / divisorDuracionDeCorreteo));
            
            yield return null;
        }
        miSprite.flipX = !miSprite.flipX;
    }

    private void ActualizarEstado()
    {
        // Actualiza el estado actual según las probabilidades y condiciones que desees
        // Puedes usar Random.Range para generar números aleatorios y decidir el siguiente estado
        estadoActual = Random.Range(0, 3);
    }
    // Update is called once per frame

}
