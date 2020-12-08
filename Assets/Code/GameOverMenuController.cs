using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMenuController : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI lastScore;

    void OnEnable()
    {
        highScore.text = "High Score: " + GameController.HighScore;
        lastScore.text = "Current Score: " + GameController.LastScore;
    }
    
}
