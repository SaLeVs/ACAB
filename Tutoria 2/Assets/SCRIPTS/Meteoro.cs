using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoro : MonoBehaviour
{

    public GameObject meteorPrefab; // Prefab do meteoro.
    public int meteorCount = 5; // Quantidade de meteoros a serem gerados.
    public float spawnRate = 3.0f; // Taxa de gera��o de meteoros (em segundos).

    private bool isShooting = false; // Indica se o bot�o de tiro est� sendo pressionado.

    void Update()
    {
        // Verifica se o bot�o de tiro (Fire1) foi pressionado.
        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
            StartMeteorRain();
        }

        // Verifica se o bot�o de tiro foi solto.
        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }
    }

    void StartMeteorRain()
    {
        InvokeRepeating("SpawnMeteor", 0f, spawnRate); // Chama a fun��o SpawnMeteor a cada intervalo de tempo.
    }

    void SpawnMeteor()
    {
        if (isShooting) // Verifica se o bot�o de tiro ainda est� pressionado.
        {
            for (int i = 0; i < meteorCount; i++)
            {
                Vector2 randomPosition = new Vector2(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height));
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(randomPosition);
                worldPosition.z = 0f; // Define a coordenada z como 0 para garantir que os meteoros n�o sejam instanciados fora da tela.
                Instantiate(meteorPrefab, worldPosition, Quaternion.identity);
            }
        }
        else
        {
            CancelInvoke("SpawnMeteor"); // Cancela a repeti��o quando o bot�o de tiro � solto.
        }
    }
}