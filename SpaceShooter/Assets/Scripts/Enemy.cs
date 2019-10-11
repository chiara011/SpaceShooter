using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    private float _speedVertical = 1.00f;

    void Start()
    {
        
    }

    
    void Update()
    {
        EnemyMovement();
        DestroyEnemy();

    }

    void EnemyMovement(){
        transform.Translate(Vector3.down * _speedVertical * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other){
        if( other.gameObject.tag == "Laser"){
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
            
    }

    

    void DestroyEnemy(){
        if (transform.position.y <= -9.00f)
        {
           Destroy(this.gameObject);
       }
    }
}

