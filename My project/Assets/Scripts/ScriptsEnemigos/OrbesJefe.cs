using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbesJefe : MonoBehaviour
{
    [SerializeField] int dagno;
    [SerializeField] float duracionProyectil;
    [SerializeField] float divisorDuracionProyectil;
    [SerializeField] float velocidadProyectil;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovimientoOrbe());
    }
    private IEnumerator MovimientoOrbe()
    {
        float tiempoInicio = Time.time;
        Vector2 posicionInicial = transform.position;
        Vector2 posicionObjetivo = new Vector2(transform.position.x, transform.position.y + velocidadProyectil);

        while (Time.time < tiempoInicio + duracionProyectil / divisorDuracionProyectil)
        {
            transform.position = Vector2.Lerp(posicionInicial, posicionObjetivo, (Time.time - tiempoInicio) / (duracionProyectil / divisorDuracionProyectil));
            Destroy(gameObject,5);
            yield return null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            jugador.ModificarVida(-dagno);
            Debug.Log(" PUNTOS DE DAÑO REALIZADOS AL JUGADOR " + dagno);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
