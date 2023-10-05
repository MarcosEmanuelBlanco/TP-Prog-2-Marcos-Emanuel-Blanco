using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjAleatorio : MonoBehaviour
{
    [SerializeField] private GameObject[] orbesPrefabs; //Más adelante, estos objetos tendrán efectos al colisionar con enemigos.

    [SerializeField]
    [Range(0.5f, 10f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 20f)]
    private float tiempoIntervalo;

    void Start()
    {
        InvokeRepeating(nameof(GenerarObjetoAleatorio), tiempoEspera, tiempoIntervalo);
    }

    void GenerarObjetoAleatorio()
    {
        int indexAleatorio = Random.Range(0, orbesPrefabs.Length);
        GameObject prefabAleatorio = orbesPrefabs[indexAleatorio];
        Instantiate(prefabAleatorio, transform.position, Quaternion.identity);
    }
    private void OnBecameInvisible()
    {
        Debug.Log("El SpriteRenderer deja de ser visible por las cámaras en la escena");
        CancelInvoke(nameof(GenerarObjetoAleatorio));
    }

    private void OnBecameVisible()
    {
        Debug.Log("El SpriteRenderer es visible por las cámaras en la escena");
        InvokeRepeating(nameof(GenerarObjetoAleatorio), tiempoEspera, tiempoIntervalo);
    }
}
