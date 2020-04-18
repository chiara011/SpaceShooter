using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    private float _speedVertical = 4.00f;
    private Player _player; 

    void Start(){
        _player = GameObject.Find("Player").GetComponent<Player>();
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
            if(_player != null) _player.UpdateScore(10);
            Destroy(this.gameObject);
        }
        if( other.gameObject.tag == "Player")
        {
            if (_player != null)  _player.Damage();
            Destroy(this.gameObject);
        }
    }

}

