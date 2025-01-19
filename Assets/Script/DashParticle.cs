using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashParticle : MonoBehaviour
{
    ParticleSystem dashParticle;
    // Start is called before the first frame update
    void Start()
    {
        dashParticle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dashParticle.Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            dashParticle.Stop();
        }
    }
}
