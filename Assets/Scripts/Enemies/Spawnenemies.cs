//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Spawnenemies : MonoBehaviour
//{

//    public GameObject enemyPrefab;
//    public GameObject player;

//    [SerializeField] private float _spawnIntervall;
//    public float _spawnRange;
//    private float _timeSinceLastSpawn;

//    void Start()
//    {
//        StartCoroutine(SpawnAnEnemy()); 
//    }

//    IEnumerator SpawnAnEnemy()
//    {
//        Vector2 spawnPos = player.transform.position;
//        spawnPos += Random.insideUnitCircle.normalized * _spawnRange;

//        Vector3 enemyDirection = new Vector3(player.transform.position.x, 0, player.transform.position.z) - new Vector3(spawnPos.x, 0, spawnPos.y);
//        Quaternion enemyRotation = Quaternion.LookRotation(enemyDirection, Vector3.up);

//        Instantiate(enemyPrefab, new Vector3(spawnPos.x, 0, spawnPos.y), enemyRotation);
//        yield return new WaitForSeconds(_spawnIntervall);
//        StartCoroutine(SpawnAnEnemy());
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject player;
    public float spawnRange;
    [SerializeField] private float _spawnInterval;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector2 spawnPosition = GetRandomSpawnPosition();
            Vector2 playerDirection = (Vector2) player.transform.position - spawnPosition;
            float spawnAngle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion spawnRotation = Quaternion.Euler(0, 0, spawnAngle);

            Instantiate(enemyPrefab, spawnPosition, spawnRotation);

            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private Vector2 GetRandomSpawnPosition()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 randomOffset = Random.insideUnitCircle.normalized * spawnRange;
        Vector2 spawnPosition = playerPosition + randomOffset;

        return spawnPosition;
    }
}

