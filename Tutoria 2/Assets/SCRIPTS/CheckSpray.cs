using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpray : MonoBehaviour
{
    public static bool checkSpray = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            checkSpray = true;
        }
    }
}
