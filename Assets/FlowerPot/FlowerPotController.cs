using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GJ.Calculation;

public class FlowerPotController : MonoBehaviour
{
    ///// <summary>スコアのプロパティ</summary>
    //public int Score => _score;

    /// <summary>成長するのに必要なもの</summary>
    [SerializeField]
    [Header("成長するのに必要なもの")]
    List<GrowthPointLimit> _growth = new List<GrowthPointLimit>();

    /// <summary>現在の成長ポイント</summary>
    [SerializeField]
    [Header("現在の成長ポイント")]
    int _growthPoint;

    /// <summary>花を生成する位置</summary>
    [SerializeField]
    [Header("花を生成する位置")]
    SpriteRenderer _flowerPos;

    /// <summary>雨のTag</summary>
    [SerializeField]
    [Header("雨のTag")]
    string _rainTag;

    /// <summary>土のスプライト</summary>
    [SerializeField]
    [Header("土のスプライト")]
    Sprite _soil;

    /// <summary>植木鉢</summary>
    [SerializeField]
    [Header("植木鉢")]
    GameObject _flowerPotPrefab;

    [SerializeField]
    [Header("植木鉢を変えるクールダウン")]
    float _interver = 0.1f;

    /// <summary>現在の花の成長レベル</summary>
    int _level;
    /// <summary>成長に必要なランダムなポイント</summary>
    int _randomGrowthPoint;
    /// <summary>調整する</summary>
    const int OFFSET = 1;
    ///// <summary>スコア</summary>
    //int _score;

    float _timer;

    void Start()
    {
        //Random.Rangeをして必要なポイントを変えている
        _randomGrowthPoint = Calculator.RandomNumber(_growth[0].MiniGrowthPoint, _growth[0].MaxGrowthPoint);
    }

    void Update()
    {
        _timer += Time.deltaTime;
        //クールダウンが終わったら
        if(_timer > _interver)ChengeFlowerPot();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //雨に触れたら
        //if (collision.gameObject.tag == _rainTag) Growth();
        Growth();     
    }

    /// <summary>植木鉢を変える</summary>
    void ChengeFlowerPot()
    {
        if (Input.GetButton("Jump"))
        {          
            //_score += _growthPointLimit[_level].ManyPoint;//スコアを追加
            _growthPoint = 0;//成長ポイントをリセットリセット
            _level = 0;//レベルをリセット
            _flowerPos.sprite = _soil;//土に戻す
            //Random.Rangeをして成長に必要なポイントを変えている
            _randomGrowthPoint = Calculator.RandomNumber(_growth[0].MiniGrowthPoint, _growth[0].MaxGrowthPoint);
            _timer = 0;
        }
    }

    //花を成長させる
    void Growth()
    {
        _growthPoint++;

        //必要な成長ポイントまで達したら
        if (_growthPoint >= _randomGrowthPoint && _level < _growth.Count)
        {
            _flowerPos.sprite = _growth[_level].Flower;//スプライトを変更
            //_score += _growthPointLimit[_level].Point;//スコアを追加        
            _randomGrowthPoint = Calculator.RandomNumber(_growth[_level].MiniGrowthPoint, _growth[_level].MaxGrowthPoint);
            if(_level < _growth.Count - OFFSET)_level++;//レベルを上げる
        }
    }

    /// <summary>成長するのに必要なポイントと成長用の花を設定する</summary>
    [Serializable]
    public class GrowthPointLimit
    {
        /// <summary>この状態に成長するのに必要な最小ポイントのプロパティ</summary>
        public int MiniGrowthPoint  => _miniGrowthPoint;
        /// <summary>この状態に成長するのに必要な最大ポイントのプロパティ</summary>
        public int MaxGrowthPoint => _maxGrowthPoint;
        /// <summary>花のスプライトのプロパティ</summary>
        public Sprite Flower => _flower;
        /// <summary>成長したときに貰えるスコアのプロパティ<summary>
        //public int Point => _score;
        ///// <summary>植木鉢を変えたときに貰える大量のスコアのプロパティ</summary>
        //public int ManyPoint  => _manyScore;


        /// <summary>レベル</summary>
        [SerializeField]
        [Header("レベル")]
        string _level;

        /// <summary>この状態に成長するのに必要な最小ポイント</summary>
        [SerializeField]
        [Header("この状態に成長するのに必要な最小ポイント")]
        int _miniGrowthPoint;

        /// <summary>この状態に成長するのに必要な最大ポイント</summary>
        [SerializeField]
        [Header("この状態に成長するのに必要な最大ポイント")]
        int _maxGrowthPoint;

        /// <summary>花のスプライト</summary>
        [SerializeField]
        [Header("花のスプライト")]
        Sprite _flower;

        ///// <summary>成長したときに貰えるスコア</summary>
        //[SerializeField]
        //[Header("成長したときに貰えるスコア")]
        //int _score;

        ///// <summary>植木鉢を変えたときに貰える大量のスコア</summary>
        //[SerializeField]
        //[Header("植木鉢を変えたときに貰える大量のスコア")]
        //int _manyScore;
    }
}
