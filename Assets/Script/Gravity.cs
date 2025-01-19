using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float radius =5f;
    private Rigidbody2D target;
    public AnimationCurve curve;
    public float forceFactor = -2f;
    #if UNITY_EDITOR
    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    #endif
    private void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        var dist = Vector3.Distance(transform.position, target.transform.position);
        if(dist < radius)
        {
            var direction = (target.transform.position - transform.position).normalized;
            var force = forceFactor * curve.Evaluate(dist/radius) * direction;
            target.AddForce(force, ForceMode2D.Force);
        }
    }
}
