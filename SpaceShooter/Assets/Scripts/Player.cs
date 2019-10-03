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

    public float horizontalInput;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        //take the current position to 0,0,0
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        LaserShooting();
    }

    void LaserShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_LaserPrefab, transform.position, Quaternion.identity);
        }
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