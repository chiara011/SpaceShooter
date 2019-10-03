using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speedVertical = 8f;
   
   
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.up * _speedVertical * Time.deltaTime);
    }
}
