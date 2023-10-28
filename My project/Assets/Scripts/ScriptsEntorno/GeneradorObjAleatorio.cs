using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjAleatorio : MonoBehaviour
{
    [SerializeField] private int cantidadAleatorios; //Más adelante, estos objetos tendrán efectos al colisionar con enemigos.

    [SerializeField]
    [Range(0.5f, 10f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 20f)]
    private float tiempoIntervalo;

    private PoolObjetos poolObjetos;

    private void Awake()
    {
        poolObjetos = GetComponent<PoolObjetos>();
    }
    void Start()
    {
        InvokeRepeating(nameof(GenerarObjetoAleatorio), tiempoEspera, tiempoIntervalo);
    }

    void GenerarObjetoAleatorio()
    {
        int indexAleatorio = Random.Range(0, cantidadAleatorios);
        GameObject pooledFuego = poolObjetos.GetPooledFuego();
        GameObject pooledBaba = poolObjetos.GetPooledBaba();
        GameObject pooledHielo = poolObjetos.GetPooledHielo();
        if(indexAleatorio == 0 && pooledFuego != null)
        {
            pooledFuego.transform.position = transform.position;
            pooledFuego.transform.rotation = Quaternion.identity;
            pooledFuego.SetActive(true);
        }

        if (indexAleatorio == 1 && pooledBaba != null)
        {
            pooledBaba.transform.position = transform.position;
            pooledBaba.transform.rotation = Quaternion.identity;
            pooledBaba.SetActive(true);
        }

        if (indexAleatorio == 2 && pooledHielo != null)
        {
            pooledHielo.transform.position = transform.position;
            pooledHielo.transform.rotation = Quaternion.identity;
            pooledHielo.SetActive(true);
        }
        //GameObject prefabAleatorio = orbesPrefabs[indexAleatorio];
        //Instantiate(prefabAleatorio, transform.position, Quaternion.identity);
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
