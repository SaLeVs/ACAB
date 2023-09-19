using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraGelo : MonoBehaviour
{
    public Slider slider;

    
    public void AlterarVida(float tempoDeGelo)
    {
        slider.value = tempoDeGelo;
    }
}
