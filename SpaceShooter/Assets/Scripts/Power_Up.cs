using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Up : MonoBehaviour
{
    [SerializeField]
    private float _speedVertical = 3f;

    void Start(){
        
    }

    
    void Update(){
        PowerUpMovement();
        DestroyPowerUp();
    }

    void PowerUpMovement(){
        transform.Translate(Vector3.down * _speedVertical * Time.deltaTime);
    }
    void DestroyPowerUp(){
        if (transform.position.y <= -9.00)
        {
           Destroy(this.gameObject);
       }
    }
    private void OnTriggerEnter2D(Collider2D other){
         if( other.tag == "Player"){

            Player player = other.transform.GetComponent<Player>();

            if (player != null) {    
                 player.TripleShotActive();
            }

             Destroy(this.gameObject);
         }
    }


}
