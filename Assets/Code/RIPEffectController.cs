using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIPEffectController : MonoBehaviour
{
    public GameObject ripGo;

    public void PlayRIP()
    {
        StartCoroutine(PlayeRIPWithDelay());
    }

    IEnumerator PlayeRIPWithDelay()
    {
        yield return new WaitForSeconds(1);
        ripGo.transform.position = new Vector3(transform.position.x, -0.1f, transform.position.z);
        ripGo.SetActive(true);

        GetComponent<UITweenScaleController>().enabled = true;
    }
}
