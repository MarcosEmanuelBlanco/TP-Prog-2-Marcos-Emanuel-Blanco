using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoRocoso : MonoBehaviour
{

    private Animator miAnimator;
    private AtaqueRocoso vinculoAtaque;
    [SerializeField] private Transform sensorBorde;
    [SerializeField] private float distancia;
    [SerializeField] private float velocidad;
    [SerializeField] private bool preferenciaDeteccion;
    [SerializeField] private bool yendoDerecha;
    public bool aturdido;
    [SerializeField] private float duracionAturdimiento;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        miAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        vinculoAtaque = GetComponent<AtaqueRocoso>();
    }

    private void FixedUpdate()
    {
        if(vinculoAtaque.atacando == false && aturdido == false)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
        }
        RaycastHit2D rayoSensorBorde = Physics2D.Raycast(sensorBorde.position, Vector2.down, distancia);

        if (rayoSensorBorde == preferenciaDeteccion)
        {
           
            Girar();

        }
    }
    private void AnimacionMovimiento()
    {
        if(vinculoAtaque.atacando == false && aturdido == false)
        {
            miAnimator.SetBool("Persiguiendo", true);
        }

    }

    public void Girar()
    {
        yendoDerecha = !yendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    public IEnumerator Aturdirse()
    {
        aturdido = true;
        miAnimator.SetBool("Aturdimiento", true);
        yield return new WaitForSeconds(duracionAturdimiento);
        aturdido = false;
        miAnimator.SetBool("Aturdimiento", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(sensorBorde.transform.position + Vector3.down * distancia, sensorBorde.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        AnimacionMovimiento();
    }

    public void ModificarVelocidad(float puntos)
    {
        velocidad += puntos;
    }
}
