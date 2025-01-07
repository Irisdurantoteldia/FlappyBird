using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab de l'obstacle
    public float spawnRate = 6f; // Interval de generació (segons)
    public float spawnHeightMin = 0f; // Alçada mínima de generació
    public float spawnHeightMax = 0;  // Alçada màxima de generació
    private float nextSpawnTime; // Temps per al pròxim spawn

    void Start()
    {
        // Comprova que obstaclePrefab està assignat
        if (obstaclePrefab == null)
        {
            Debug.LogError("ObstaclePrefab no està assignat al Inspector. Assigna un prefab per continuar.");
            return;
        }

        // Generar el primer obstacle
        SpawnObstacle();
        nextSpawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        // Si s'ha arribat al temps de spawn, generar un nou obstacle
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnObstacle()
    {
        // Comprovar que el prefab no és nul abans d'intentar instanciar-lo
        if (obstaclePrefab != null)
        {
            float spawnPosY = Random.Range(spawnHeightMin, spawnHeightMax);
            Instantiate(obstaclePrefab, new Vector3(transform.position.x, spawnPosY, 0), Quaternion.identity);
        }
        else
        {
            Debug.LogError("ObstaclePrefab és nul en temps d'execució. Assegura't que el prefab no ha estat destruït.");
        }
    }

    void OnDestroy()
    {
        // Afegeix un log si el prefab està destruït al destruir aquest spawner
        if (obstaclePrefab == null)
        {
            Debug.LogWarning("ObstaclePrefab s'ha destruït quan ObstacleSpawner s'ha destruït.");
        }
    }
}
