using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _Enemy;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _tripleShotPowerUpPrefab;

    private bool _stopSpawning = false;

    void Start() {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    void Update()
    {
       
    }

    IEnumerator SpawnEnemyRoutine(){
        while (_stopSpawning == false)
        {
            Vector3 spawnposition = new Vector3(Random.Range(-8f, 8f), 7.00f, 0.00f);
            GameObject newEnemy = Instantiate(_Enemy, spawnposition, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5);
        }
    }

    IEnumerator SpawnPowerUpRoutine(){
        while (_stopSpawning == false)
        {
            Vector3 spawnposition = new Vector3(Random.Range(-8f, 8f), 7.00f, 0.00f);
            Instantiate(_tripleShotPowerUpPrefab, spawnposition, Quaternion.identity);
            float seconds = Random.Range(3f,8f);

            yield return new WaitForSeconds(seconds);
        }
    }


    public void OnPlayerDeath(){
        _stopSpawning = true;
    }
}
