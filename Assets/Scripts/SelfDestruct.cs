using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]
    float delayTime = 1.5f;

    void OnEnable()
    {
        StartCoroutine(delayDelete());
    }

    IEnumerator delayDelete()
    {
        yield return new WaitForSeconds(delayTime);
        DestroyImmediate(gameObject);
    }
}
