using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _startingSpeedHorizontal = 5f;
    [SerializeField]
    private float _speedHorizontal;
    [SerializeField]
    private float _speedVertical;
    [SerializeField]
    private float _startingSpeedVertical = 5f;
    [SerializeField]
    private GameObject _LaserPrefab;
    [SerializeField]
    private float _fireRate = 1.5f;
    private float _canFire = -1;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private int _score; 
    public float horizontalInput;
    public float verticalInput;
    private SpawnManager _spawnManager;
    private UIManager _uiManager;
    [SerializeField]
    private bool _tripleShotActive;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private bool _speedPowerActive = false; 
    [SerializeField]
    private bool _canBeDamaged = true; 
    [SerializeField]
    private bool _shieldPowerActive = false; 
    [SerializeField]
    private GameObject _shieldVisualizer;

    
    void Start(){ 
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _tripleShotActive = false;
        _canBeDamaged = true;
        _shieldVisualizer.SetActive(false);
        _score = 0; 
        _uiManager.UpdateLives(_lives);

        if (_spawnManager == null)
            Debug.LogError("The Spawn Manager is NULL");

        if (_uiManager == null)
            Debug.LogError("The UI Manager is NULL");
    }

    void Update(){
        CalculateMovement();
       
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire){
            LaserShooting();
        }
    }

    void LaserShooting(){
     _canFire = Time.time + _fireRate;

     if(_tripleShotActive == true){
        Instantiate (_tripleShotPrefab, new Vector3(transform.position.x -0.64f,transform.position.y + 0.1f,transform.position.z -8.58f), Quaternion.identity);
         }
     else
        Instantiate(_LaserPrefab, new Vector3(transform.position.x, transform.position.y + 1.05f, transform.position.z), Quaternion.identity);
    }
    void CalculateMovement(){
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        _speedHorizontal = horizontalInput * _startingSpeedHorizontal;
        _speedVertical = verticalInput * _startingSpeedVertical;

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
        if (_canBeDamaged == true){
            _lives--;
            _uiManager.UpdateLives(_lives);

            if (_lives == 0){
                _spawnManager.OnPlayerDeath();
                Destroy(this.gameObject);
            }
        }
    }

    public void TripleShotActive(){

        _tripleShotActive = true;
        StartCoroutine(TripleShot());
        
    }

    IEnumerator TripleShot(){
           yield return new WaitForSeconds(5);
           _tripleShotActive = false;  
    }

    public void SpeedActive(){

        _speedPowerActive = true; 
        StartCoroutine(SpeedPowerUp());
    }

    IEnumerator SpeedPowerUp(){
        while (_speedPowerActive == true){
            _startingSpeedVertical = 10f; 
            _startingSpeedHorizontal = 10f; 
            yield return new WaitForSeconds(5);
            _startingSpeedVertical = 5f; 
            _startingSpeedHorizontal = 5; 
            _speedPowerActive = false; 
        }
    }

    public void ShieldActive(){
        _shieldPowerActive = true; 
        StartCoroutine(ShieldPowerUp());

    }

    IEnumerator ShieldPowerUp(){
        while (_shieldPowerActive == true){
            _canBeDamaged = false;
            _shieldVisualizer.SetActive(true);
            yield return new WaitForSeconds(5);
            _canBeDamaged = true;  
            _shieldPowerActive = false; 
            _shieldVisualizer.SetActive(false);
        }
    }

    public void  UpdateScore(int points){
        _score = _score + points; 
        _uiManager.UpdateScore(_score);
    }


}

