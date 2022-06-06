using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    [Tooltip("スコアのテキスト")]
    [SerializeField] Text _ScoreText;
    [Tooltip("咲いた花の本数のテキスト")]
    [SerializeField] Text _bloomedText;

    private void Start()
    {
        _ScoreText.text = ScoreScript.Score.ToString();
        _bloomedText.text = ScoreScript.FlowerScore.ToString();
    }
}
