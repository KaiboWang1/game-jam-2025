using System.Collections;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float shakeFrequency = 60;
    public float shakeMagnitude = 1f;
    public float maxAngle = 10f;
    
    IEnumerator Shaking()
    {
        while (true)
        {
            var offset = Random.insideUnitSphere * shakeMagnitude;
            transform.localPosition = offset;
            transform.localEulerAngles = new Vector3(0,0, Random.Range(-maxAngle,maxAngle));
            yield return new WaitForSeconds(1 / shakeFrequency);
        }
    }
    void Start()
    {
        StartCoroutine(Shaking());
    }
}
