using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemies : MonoBehaviour
{

    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private float _spawnIntervall;
    private float _timeSinceLastSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        if(_timeSinceLastSpawn >= _spawnIntervall)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(Random.Range(5f, 5f), Random.Range(-6f, 6f), 0), Quaternion.identity);
            _timeSinceLastSpawn = 0;
        }
    }
}
