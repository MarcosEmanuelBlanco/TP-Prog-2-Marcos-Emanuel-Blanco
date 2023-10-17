using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI miTextoVida;
    [SerializeField] TextMeshProUGUI miTextoRocososEnojados;
    [SerializeField] TextMeshProUGUI miTextoRocososComunes;
    [SerializeField] TextMeshProUGUI miTextoGranRocoso;
    public void ActualizarTextoHUDVida(string nuevoTexto)
    {
        miTextoVida.text = nuevoTexto;
    }

    public void ActualizarTextoHUDGranRoc(string nuevoTexto)
    {
        miTextoGranRocoso.text = "3: " + nuevoTexto + " / 1";
    }

    public void ActualizarTextoHUDRocComunes(string nuevoTexto)
    {
        miTextoRocososComunes.text = "2: " + nuevoTexto + " / 3";
    }

    public void ActualizarTextoHUDRocEnoj(string nuevoTexto)
    {
        miTextoRocososEnojados.text = "1: " + nuevoTexto + " / 3";
    }
}
