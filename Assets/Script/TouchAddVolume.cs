using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class TouchAddVolume : MonoBehaviour
{
    public float volumeChange = -1f;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            other.GetComponent<PlayerMovement>().OnHit(volumeChange);
            gameObject.SetActive(false);
        }
    }
}
