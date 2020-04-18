using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Sprite[] _liveSprites;
    void Start()
    {
        _scoreText.text = "Score: " + 0; 
        
    }

    
    void Update()
    {
    }

    public void UpdateScore(int _playerScore){
        _scoreText.text = "Score: " + _playerScore.ToString(); 
    }

    public void UpdateLives(int currentLives){
        _livesImg.sprite = _liveSprites[currentLives];
    }
}
