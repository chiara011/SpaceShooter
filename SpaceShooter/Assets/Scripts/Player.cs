using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
 
    [SerializeField]
    private float _speedHorizontal = 5f;
    [SerializeField]
    private float _speedVertical = 5f;

    [SerializeField]
    private GameObject _LaserPrefab;

    [SerializeField]
    private GameObject _Enemy;

    [SerializeField]
    private float _fireRate = 1.5f;
    private float _canFire = -1;

    public float horizontalInput;
    public float verticalInput;

    
    void Start()
    {
        //take the current position to 0,0,0
        transform.position = new Vector3(0, 0, 0);
        EnemyCreation();
    }

    
    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            LaserShooting();
        }
 
    }

    void EnemyCreation()
    {
        
        Vector3 spawnposition = new Vector3(-8,5.00f,0.00f);
        for(int i=0; i <= 8; i++) {
            Instantiate(_Enemy, spawnposition,Quaternion.identity);
            spawnposition.x = spawnposition.x + 2;
         }

    }

    void LaserShooting()
    {
     _canFire = Time.time + _fireRate;
     Instantiate(_LaserPrefab, new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z), Quaternion.identity);
    
    }
    void CalculateMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        _speedHorizontal = horizontalInput * 5;
        _speedVertical = verticalInput * 5;

        transform.Translate(Vector3.right * _speedHorizontal * Time.deltaTime);
        transform.Translate(Vector3.up * _speedVertical * Time.deltaTime);

        //transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime)
        //or
        //Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        //transform.Translate(direction * _speed * Time.deltaTime);

        //if (transform.position.y >= 7.00)
        //{
        //    transform.Translate(new Vector3(transform.position.x, -14.00f,0));
        //}

        //if(transform.position.y<= -7.00)
        //{
        //    transform.Translate(new Vector3(transform.position.x, 14.00f, 0));
        //}

        if(transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0,0), 0);
        }

        if (transform.position.y <= -4.00)
        {
            transform.position = new Vector3(transform.position.x, -4.00f, 0);
        }

        if (transform.position.x >= 11.40)
        {
            transform.Translate(new Vector3(-22.80f, transform.position.y, 0));
        }

        if (transform.position.x <= -11.40)
        {
            transform.Translate(new Vector3(22.80f, transform.position.y, 0));
        }
    }
}

