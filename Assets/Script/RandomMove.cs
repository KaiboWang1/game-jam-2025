using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    public float minRotateSpeed = 1f;
    public float maxRotateSpeed = 2f;
    public float maxMoveSpeed = 0.3f;
    // Start is called before the first frame update
    private float _rot;
    private Vector3 _move;
    void Start()
    {
        _rot = Random.Range(minRotateSpeed, maxRotateSpeed);
        _move = new Vector3(Random.Range(-maxMoveSpeed, maxMoveSpeed), Random.Range(-maxMoveSpeed, maxMoveSpeed), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_move * Time.deltaTime);
        transform.Rotate(0, 0, _rot * Time.deltaTime);        
    }
}
