using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartMenuController : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        highScore.text = "High Score: " + GameController.HighScore;
    }

}
