using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // Pontos de spawn
    public GameObject enemyPrefab; // Prefab do inimigo
    public float spawnInterval = 1.0f; // Intervalo de spawn
    public bool isRandom = true; // Se o spawn é aleatório ou não

    private void Start()
    {
        // Inicia a Coroutine de spawn
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (isRandom)
            {
                // Escolhe um ponto de spawn aleatório
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // Cria um novo inimigo no ponto de spawn
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                newEnemy.SetActive(true);
            }

            // Aguarda o intervalo de spawn antes de continuar o loop
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
