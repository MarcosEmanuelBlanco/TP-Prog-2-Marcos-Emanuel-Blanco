using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjecucionAnimaciones : MonoBehaviour
{
    private Animator miAnimator;
    // Start is called before the first frame update
    void Start()
    {
        miAnimator = GetComponent<Animator>();
    }
    public void ActivarAnimacionAtaque()
    {
        miAnimator.SetTrigger("Atacando");
        miAnimator.SetBool("Persiguiendo", false);
    }

    public void ActivarAnimacionAturdimiento()
    {
        miAnimator.SetBool("Aturdimiento", true);
    }

    public void DesactivarAnimacionAturdimiento()
    {
        miAnimator.SetBool("Aturdimiento", false);
    }

    public void ActivarAnimacionMovimiento()
    {
        miAnimator.SetBool("Persiguiendo", true);
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<AtaqueRocoso>().GetAtacando() == false && gameObject.GetComponent<MovimientoRocoso>().GetAturdimiento() == false)
        {
            ActivarAnimacionMovimiento();
        }
    }
}
