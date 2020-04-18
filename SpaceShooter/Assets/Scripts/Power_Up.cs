using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Up : MonoBehaviour
{
    [SerializeField]
    private float _speedVertical = 3f;
    [SerializeField]
    private int powerUpId; // 0 for Triple Shot | 1 for Speed | 2 for Shield
   
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
            
            if(player!=null){
                switch (powerUpId){
                    case 0: 
                        player.TripleShotActive();
                        break; 
                    case 1: 
                        player.SpeedActive();
                        break; 
                    case 2: 
                        player.ShieldActive();
                        break; 
                }
            }

             Destroy(this.gameObject);
         }
    }


}
