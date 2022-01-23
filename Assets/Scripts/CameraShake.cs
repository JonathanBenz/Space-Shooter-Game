using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }
    public void Play() {
        StartCoroutine(Shake());
    }

    IEnumerator Shake() {
        float time = 0f;
        while (time < shakeDuration) {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
}
