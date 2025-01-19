using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class SpeedScoreInfo
{
    float speed;
    float scoreByDistance;

}
[RequireComponent(typeof(Rigidbody2D))]
public class SpeedScore : MonoBehaviour
{
    public float speed;
    public float scoreByDistance;
    private float _distance;
    // Start is called before the first frame update
    public Animator animator;
    public TextMeshProUGUI scoreText;

    public void ShowScoreUI()
    {
        animator.Play("Show");
    }
    public void HideScoreUI()
    {
        animator.Play("Hide");
    }
    public void UpdateScoreByDistance()
    {
        var rb = GetComponent<Rigidbody2D>();
        float score = 0f;
        if(rb.velocity.magnitude >= speed)
        {
            _distance += rb.velocity.magnitude * Time.deltaTime;
            score = _distance * scoreByDistance;
            scoreText.text = score.ToString("F1");
            ShowScoreUI();
        }
        else{
            HideScoreUI();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
