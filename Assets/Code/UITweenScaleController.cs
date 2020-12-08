using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]

public class UITweenScaleController : MonoBehaviour {

    public LeanTweenType easeType;
    public float duration;
    public float delay;
    public bool runOnAwake;
    public Vector3 toScale;

    private void OnEnable()
    {
        
        if (runOnAwake)
        {
            LeanTween.scale(gameObject, toScale, duration).setEase(easeType).setDelay(delay);
        }
    }


}
