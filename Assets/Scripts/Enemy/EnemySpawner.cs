using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints; // Pontos de spawn
    [SerializeField] private GameObject[] _enemyPrefabs; // Prefab do inimigo
    [SerializeField] private float _spawnInterval = 1.0f; // Intervalo de spawn
    [SerializeField] private bool _isRandom = true; // Se o spawn é aleatório ou não
    [SerializeField] private bool _stopSpawn = false;

    private void Start()
    {
        // Inicia a Coroutine de spawn
        StartCoroutine(SpawnEnemies());
    }
    public void SetStopSpawn(bool value)
    {
        _stopSpawn = value;
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (_isRandom && _stopSpawn == false)
            {
                int randomIndex = Random.Range(0, _spawnPoints.Length);
                Spawn(randomIndex);
            }

            // Aguarda o intervalo de spawn antes de continuar o loop
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
    public void Spawn(int randomIndex)
    {
        
        // Escolhe um ponto de spawn aleatório
        Transform spawnPoint = _spawnPoints[randomIndex];

        // Cria um novo inimigo no ponto de spawn
        GameObject newEnemy = Instantiate(_enemyPrefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);
        newEnemy.SetActive(true);
    }
    public void SetSpawnInterval(float value)
    {
        _spawnInterval = value;
    }
}
