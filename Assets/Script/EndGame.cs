using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            int playerScore = PlayerPrefs.GetInt("PlayerScore");
            scoreText.text = playerScore.ToString();
            PlayerPrefs.SetInt("PlayerScore", 0);
            Debug.Log("Loaded score: " + playerScore);
        }
        else
        {
            Debug.Log("No saved score found!");
        }
    }
}
