using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        GameController.instance.onCurrentScoreChanged += OnValueChanged;
    }

    void OnDisable()
    {
        GameController.instance.onCurrentScoreChanged -= OnValueChanged;
    }

    void OnValueChanged(int value)
    {
        GetComponent<TextMeshProUGUI>().text = "SCORE: " + value.ToString();
    }

}
