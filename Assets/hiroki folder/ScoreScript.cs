using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    int m_score;
    int m_flowerScore = 0;
    Text m_scoreText=default;
    

    // Start is called before the first frame update
    public void AddScore(int score)
    {
        m_score += score;
    }
    public void AddFlowerScore()
    {
        m_flowerScore++; 
    }
    void Start()
    {
        m_scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_scoreText.text =("score:"+ m_score.ToString());
    }
}
