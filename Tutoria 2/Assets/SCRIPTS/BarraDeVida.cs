using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class BarraDeVida : MonoBehaviour
{
    public Slider slider;


    public void ColocarVidaMaxima(float vida)
    {
        slider.maxValue = vida;
        slider.value = vida;

    }

    public void AlterarVida(float vida)
    {
        slider.value = vida;

    
    
    }





}
