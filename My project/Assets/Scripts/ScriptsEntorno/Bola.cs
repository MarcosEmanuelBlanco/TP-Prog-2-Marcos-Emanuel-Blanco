using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadReboteBola;
    private Rigidbody rb;
    // Start is called before the first frame update
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Rebotar(Vector2 puntoImpacto)
    {
        rb.velocity = new Vector2(-velocidadReboteBola.x * puntoImpacto.x, velocidadReboteBola.y);
    }
}
