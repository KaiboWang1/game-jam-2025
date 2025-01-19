using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowZone : MonoBehaviour
{
    public float blowForce = 10f;
    public float addVolumeRate = 0.1f;
    bool inRange = false;
    Rigidbody2D target;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if(inRange)
        {
            target.AddForce(transform.up * blowForce);
            target.GetComponent<PlayerMovement>().AddVolume(addVolumeRate * Time.deltaTime);
        }
    }
}
