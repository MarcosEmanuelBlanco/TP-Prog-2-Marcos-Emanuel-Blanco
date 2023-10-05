using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AparicionJefe : MonoBehaviour
{
    [SerializeField] private Camera Camara;
    [SerializeField] private Color ColorAparicionJefe;
    [SerializeField] private GameObject Jefe;
    [SerializeField] private float Segundos;
    [SerializeField] private Light2D IluminacionJefe;

    private float tiempoRestante;
    // Start is called before the first frame update
    void Start()
    {
        tiempoRestante = Segundos;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRestante -= Time.deltaTime;

        if(tiempoRestante <= 0)
        {
            Camara.backgroundColor = ColorAparicionJefe;
            IluminacionJefe.color = ColorAparicionJefe;
            Instantiate(Jefe, transform.position, Quaternion.identity);
            enabled = false;
        }
    }
}
