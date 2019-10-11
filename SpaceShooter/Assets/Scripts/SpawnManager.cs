using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _Enemy;
    
    
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
        while (true)
        {
            Instantiate(_Enemy, spawnposition, Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }
}
