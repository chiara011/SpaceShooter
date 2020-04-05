using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    private float _speedVertical = 4.00f;

    void Start(){
        
    }

    void Update(){
        EnemyMovement();
        RespawnEnemy();
    }

    void EnemyMovement(){
        transform.Translate(Vector3.down * _speedVertical * Time.deltaTime);
    }

    void RespawnEnemy(){
        if(transform.position.y <= -5.24f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7.00f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if( other.gameObject.tag == "Laser"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if( other.gameObject.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
                player.Damage();
            
            Destroy(this.gameObject);
        }
    }

}

