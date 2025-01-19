using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        PlayerMovement.OnVolumeDepleted += Explode;
    }

    private void OnDisable()
    {
        PlayerMovement.OnVolumeDepleted -= Explode;
    }

    void Explode()
    {
        GetComponent<PlayerMovement>().enabled = false;
        transform.localScale = Vector3.one;
        GetComponent<Animator>().SetTrigger("Dead");
    }
}
