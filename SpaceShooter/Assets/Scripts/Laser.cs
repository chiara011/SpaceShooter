using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speedVertical = 8f;

    //public float posizione_laser;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.up * _speedVertical * Time.deltaTime);

        //posizione_laser = transform.position.y;
        if (transform.position.y >= 9.00)
        {
           Destroy(this.gameObject);
       }

    }
}
