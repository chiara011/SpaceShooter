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
    private float _fireRate = 1.5f;
    private float _canFire = -1;
    [SerializeField]
    private int _lives = 3;
    public float horizontalInput;
    public float verticalInput;
    private SpawnManager _spawnManager;
    [SerializeField]
    private bool _tripleShotActive = false;
    [SerializeField]
    private GameObject _tripleShotPrefab;

    
    void Start()
    { 
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
            Debug.LogError("The Spawn Manager is NULL");
    }

    
    void Update()
    {
        CalculateMovement();
       
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire){
            LaserShooting();
        }
    }



    void LaserShooting()
    {
     _canFire = Time.time + _fireRate;

     if(_tripleShotActive == true)
        Instantiate (_tripleShotPrefab, new Vector3(transform.position.x -0.64f,transform.position.y + 0.1f,transform.position.z -8.58f), Quaternion.identity);
     else
        Instantiate(_LaserPrefab, new Vector3(transform.position.x, transform.position.y + 1.05f, transform.position.z), Quaternion.identity);
    }
    void CalculateMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        _speedHorizontal = horizontalInput * 5;
        _speedVertical = verticalInput * 5;

        transform.Translate(Vector3.right * _speedHorizontal * Time.deltaTime);
        transform.Translate(Vector3.up * _speedVertical * Time.deltaTime);

        
        if(transform.position.y >= 0)
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0,0), 0);
        

        if (transform.position.y <= -4.00)
            transform.position = new Vector3(transform.position.x, -4.00f, 0);
       

        if (transform.position.x >= 11.40)
            transform.position = new Vector3(-11.40f, transform.position.y, 0);
        

        if (transform.position.x <= -11.40)
            transform.position = new Vector3(11.40f, transform.position.y, 0);
        
    }
    public void Damage()
    {
        _lives--;

        if (_lives == 0){
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive(){

        _tripleShotActive = true;
        StartCouroutine(TripleShot());
        
    }

    IEnumerator TripleShot(){
           yield return new WaitForSeconds(5);
           _tripleShotActive = false;  
    }
}

