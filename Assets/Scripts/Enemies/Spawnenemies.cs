using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemies : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject player;

    [SerializeField] private float _spawnIntervall;
    public float _spawnRange;
    private float _timeSinceLastSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAnEnemy()); 
    }

    // Update is called once per frame
    //void Update()
    //{
    //    _timeSinceLastSpawn += Time.deltaTime;

    //    if (_timeSinceLastSpawn >= _spawnIntervall)
    //    {
    //        GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(5f, 5f), Random.Range(-6f, 6f), 0), Quaternion.identity);
    //        _timeSinceLastSpawn = 0;
            
            
    //    }
    //}
 
    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = player.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * _spawnRange;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(_spawnIntervall);
        StartCoroutine(SpawnAnEnemy());
    }
}
