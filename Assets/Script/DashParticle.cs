using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashParticle : MonoBehaviour
{
    ParticleSystem dashParticle;
    public AudioSource dashLoopAS;
    public AudioSource dashEndAS;

    public AudioClip dashEnd;
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
            dashLoopAS.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            dashParticle.Stop();
            dashEndAS.PlayOneShot(dashEnd);
            dashLoopAS.enabled = false;
        }
    }
}
