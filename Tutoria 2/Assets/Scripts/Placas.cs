using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placas : MonoBehaviour
{
    public GameObject placa;

    // Start is called before the first frame update

    
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            placa.SetActive(false);
        }
    }



}
