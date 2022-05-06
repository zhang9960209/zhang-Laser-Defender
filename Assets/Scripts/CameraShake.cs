using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initPosition;

    void Start()
    {
        initPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float flElapsedTime = 0;
        while(flElapsedTime < shakeDuration)
        {
            transform.position = initPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            flElapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initPosition;
    }

}
