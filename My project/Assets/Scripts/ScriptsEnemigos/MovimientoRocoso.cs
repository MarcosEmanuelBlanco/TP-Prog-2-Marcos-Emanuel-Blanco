using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoRocoso : MonoBehaviour
{

    //private Animator miAnimator;
    //private AtaqueRocoso vinculoAtaque;
    [SerializeField] private Transform sensorBorde;
    [SerializeField] private float distancia;
    [SerializeField] private float velocidad;
    private float velocidadReal;
    [SerializeField] private bool preferenciaDeteccion;
    [SerializeField] private bool yendoDerecha;
    public bool aturdido;
    [SerializeField] private float duracionAturdimiento;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        velocidadReal = velocidad;
        //miAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //vinculoAtaque = GetComponent<AtaqueRocoso>();
    }

    private void FixedUpdate()
    {
        if(gameObject.GetComponent<AtaqueRocoso>().GetAtacando() == false && aturdido == false)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
        }
        RaycastHit2D rayoSensorBorde = Physics2D.Raycast(sensorBorde.position, Vector2.down, distancia);

        if (rayoSensorBorde == preferenciaDeteccion && gameObject.GetComponent<AtaqueRocoso>().GetAtacando() == false)
        {
           
            Girar();

        }
    }
    /*private void AnimacionMovimiento()
    {
        if(gameObject.GetComponent<AtaqueRocoso>().GetAtacando() == false && aturdido == false)
        {
            miAnimator.SetBool("Persiguiendo", true);
        }

    }*/

    public void Girar()
    {
        yendoDerecha = !yendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    public IEnumerator Aturdirse()
    {
        aturdido = true;
        //miAnimator.SetBool("Aturdimiento", true);
        gameObject.GetComponent<EjecucionAnimaciones>().ActivarAnimacionAturdimiento();
        yield return new WaitForSeconds(duracionAturdimiento);
        aturdido = false;
        //miAnimator.SetBool("Aturdimiento", false);
        gameObject.GetComponent<EjecucionAnimaciones>().DesactivarAnimacionAturdimiento();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(sensorBorde.transform.position + Vector3.down * distancia, sensorBorde.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        //AnimacionMovimiento();
    }

    public void ModificarVelocidad(float puntos)
    {
        velocidad = puntos;
    }

    public void RestaurarVelocidad()
    {
        velocidad = velocidadReal;
    }

    public bool GetAturdimiento()
    {
        return aturdido;
    }
}
