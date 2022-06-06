using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    [Tooltip("�X�R�A�̃e�L�X�g")]
    [SerializeField] Text _ScoreText;
    [Tooltip("�炢���Ԃ̖{���̃e�L�X�g")]
    [SerializeField] Text _bloomedText;

    private void Start()
    {
        _ScoreText.text = ScoreScript.Score.ToString();
        _bloomedText.text = ScoreScript.FlowerScore.ToString();
    }
}
