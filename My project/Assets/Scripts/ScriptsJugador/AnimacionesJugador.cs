using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesJugador : MonoBehaviour
{
    private Animator miAnimator;
    private int versionAnimacionAtaque;
    // Start is called before the first frame update
    void Start()
    {
        miAnimator = GetComponent<Animator>();
    }

    public void AnimacionMovimientoJugador(int velocidad)
    {
        miAnimator.SetInteger("Velocidad", velocidad);
    }

    public void AnimacionSaltoJugador(bool contacto)
    {
        miAnimator.SetBool("EnAire", contacto);
    }

    public void AnimacionAtaqueJugador()
    {
        versionAnimacionAtaque = Random.Range(0, 2);
        miAnimator.SetTrigger("Atacando");
        if(versionAnimacionAtaque == 0)
        {
            miAnimator.SetInteger("VersionAtaque", 0);
        }
        else if (versionAnimacionAtaque == 1)
        {
            miAnimator.SetInteger("VersionAtaque", 1);
        }
    }
}
