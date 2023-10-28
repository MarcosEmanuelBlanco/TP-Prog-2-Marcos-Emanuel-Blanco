using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjetos : MonoBehaviour
{
    [SerializeField] private GameObject bolaFuego;
    [SerializeField] private GameObject bolaBaba;
    [SerializeField] private GameObject bolaHielo;
    [SerializeField] private int tamanoPoolFuego = 3;
    [SerializeField] private int tamanoPoolBaba = 3;
    [SerializeField] private int tamanoPoolHielo = 3;

    private List<GameObject> poolFuego;
    private List<GameObject> poolBaba;
    private List<GameObject> poolHielo;
    // Start is called before the first frame update
    void Start()
    {
        poolBaba = new List<GameObject>();
        poolHielo = new List<GameObject>();
        poolFuego = new List<GameObject>();
        for (int i = 0; i < tamanoPoolFuego; i++)
        {
            GameObject obj = Instantiate(bolaFuego);
            obj.SetActive(false);
            poolFuego.Add(obj);
        }

        for (int i = 0; i < tamanoPoolBaba; i++)
        {
            GameObject obj = Instantiate(bolaBaba);
            obj.SetActive(false);
            poolBaba.Add(obj);
        }

        for (int i = 0; i < tamanoPoolHielo; i++)
        {
            GameObject obj = Instantiate(bolaHielo);
            obj.SetActive(false);
            poolHielo.Add(obj);
        }
    }

    public GameObject GetPooledFuego()
    {
        foreach (GameObject obj in poolFuego)
        {
            if(!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }

    public GameObject GetPooledBaba()
    {
        foreach(GameObject obj in poolBaba)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }

    public GameObject GetPooledHielo()
    {
        foreach (GameObject obj in poolHielo)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
