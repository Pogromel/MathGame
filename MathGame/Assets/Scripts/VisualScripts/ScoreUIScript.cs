using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    float currentScore = 0;
    float scoreIncrement = 0;

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    private void Update()
    {

        // Increment the score
        scoreIncrement += Time.deltaTime * 5;
        if (scoreIncrement >= 1)
        {
            currentScore += Mathf.FloorToInt(scoreIncrement);
            scoreIncrement -= Mathf.FloorToInt(scoreIncrement);
            scoreText.text = currentScore.ToString();
        }
    }

    public void incrementScoreByDamage()
    {
        currentScore += 100;
        scoreText.text = currentScore.ToString();
    }
}
