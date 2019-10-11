using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _Enemy;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {
       
    }

    IEnumerator SpawnRoutine()
    {
        float randomX = Random.Range(-8f, 8f);
        Vector3 spawnposition = new Vector3(randomX, 7.00f, 0.00f);
        while (_stopSpawning == false)
        {
            GameObject newEnemy = Instantiate(_Enemy, spawnposition, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
