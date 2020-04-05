using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speedVertical = 8f;
    [SerializeField]
    private GameObject _tripleShotPrefab;



    void Update(){
        LaserMovement();
        DestroyLaser();

    }

    void DestroyLaser(){

        if (transform.position.y >= 9.00)
        {
            if(transform.parent)
                Destroy(transform.parent.gameObject);
        
            Destroy(this.gameObject);
       }
    }

    void LaserMovement(){
        transform.Translate(Vector3.up * _speedVertical * Time.deltaTime);
    }
}
