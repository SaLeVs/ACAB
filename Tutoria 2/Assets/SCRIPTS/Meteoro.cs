using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoro : MonoBehaviour
{

    public GameObject meteorPrefab; // Prefab do meteoro.
    public int meteorCount = 5; // Quantidade de meteoros a serem gerados.
    public float spawnRate = 3.0f; // Taxa de geração de meteoros (em segundos).

    private bool isShooting = false; // Indica se o botão de tiro está sendo pressionado.

    void Update()
    {
        // Verifica se o botão de tiro (Fire1) foi pressionado.
        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
            StartMeteorRain();
        }

        // Verifica se o botão de tiro foi solto.
        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }
    }

    void StartMeteorRain()
    {
        InvokeRepeating("SpawnMeteor", 0f, spawnRate); // Chama a função SpawnMeteor a cada intervalo de tempo.
    }

    void SpawnMeteor()
    {
        if (isShooting) // Verifica se o botão de tiro ainda está pressionado.
        {
            for (int i = 0; i < meteorCount; i++)
            {
                Vector2 randomPosition = new Vector2(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height));
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(randomPosition);
                worldPosition.z = 0f; // Define a coordenada z como 0 para garantir que os meteoros não sejam instanciados fora da tela.
                Instantiate(meteorPrefab, worldPosition, Quaternion.identity);
            }
        }
        else
        {
            CancelInvoke("SpawnMeteor"); // Cancela a repetição quando o botão de tiro é solto.
        }
    }
}