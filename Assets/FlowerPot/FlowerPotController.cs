using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GJ.Calculation;

public class FlowerPotController : MonoBehaviour
{
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

    [SerializeField]
    [Header("プレイヤーのTag")]
    string _playerTag = "Player";

    /// <summary>植木鉢</summary>
    [SerializeField]
    [Header("植木鉢")]
    GameObject _flowerPot;

    [SerializeField]
    [Header("土のスプライト")]
    Sprite _soil;

    /// <summary>植木鉢を変えるクールダウン</summary>
    [SerializeField]
    [Header("植木鉢を変えるクールダウン")]
    float _interver = 0.1f;

    /// <summary>左の範囲</summary>
    [SerializeField]
    [Header("左の範囲")]
    float _leftArea = 8f;

    /// <summary>右の範囲</summary>
    [SerializeField]
    [Header("右の範囲")]
    float _rightArea = -8f;

    /// <summary>Y軸</summary>
    [SerializeField]
    [Header("Y軸")]
    float _yPos;

    /// <summary>置き始める最初の位置</summary>
    [SerializeField]
    [Header("置き始める最初の位置")]
    float _xPos = -6;

    /// <summary>定位置に置ける数の限界</summary>
    [SerializeField]
    [Header("定位置に置ける数の限界")]
    int _potCountLimit = 12;

    [SerializeField]
    [Header("定位置に置くときの植木鉢の間隔")]
    int _space = 2;

    /// <summary>プレイヤー</summary>
    GameObject _player;
    /// <summary>スコアのスクリプト</summary>
    ScoreScript _score;
    /// <summary>現在の花の成長レベル</summary>
    int _level;
    /// <summary>成長に必要なランダムなポイント</summary>
    int _randomGrowthPoint;
    /// <summary>置いた植木鉢の数</summary>
    int _potCount;
    /// <summary>調整する</summary>
    const int OFFSET = 1;

    Collider2D _collider;

    void Start()
    {
        _player = GameObject.FindWithTag(_playerTag);
        _score = FindObjectOfType<ScoreScript>();

        if(gameObject.transform.IsChildOf(_player.transform))
        {
            _randomGrowthPoint = Calculator.RandomInt(_growth[0].MiniGrowthPoint, _growth[0].MaxGrowthPoint);
        }
        else
        {
            _collider = GetComponent<Collider2D>();
            Destroy(_collider.GetComponent<BoxCollider2D>());
        }
    }

    void Update()
    {
        if (gameObject.transform.IsChildOf(_player.transform))
        {
            //クールダウンが終わったら
            ChengeFlowerPot();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.transform.IsChildOf(_player.transform))
        {
            //雨に触れたら
            if (collision.gameObject.tag == _rainTag) Growth();
        }
    }

    /// <summary>植木鉢を変える</summary>
    void ChengeFlowerPot()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //置いた植木鉢の数が少なかったら
            if(_potCount < _potCountLimit)
            {
                Instantiate(_flowerPot, new Vector3(_xPos, _yPos, 10f), Quaternion.identity);
                _xPos += _space;
                _potCount++;
            }
            else
            {
                //新しい植木鉢をランダムな位置に生成
                Instantiate(_flowerPot, new Vector3(Calculator.RandomFloat(_leftArea, _rightArea), _yPos, 10f), Quaternion.identity);
            }
            _flowerPos.sprite = _soil;//土に変更
            //花が咲いたらスコアを追加
            if (_level == _growth.Count - OFFSET - OFFSET || _level == _growth.Count - OFFSET)
            {
                _score.AddFlowerScore();
                //蝶々だったら
                if(_level == _growth.Count - OFFSET)Generator.Instance.MoreRains();//降水量を変更
            }
            //枯れたら
            if (_level == _growth.Count) Generator.Instance.RainsFactReset();//降水量をリセット
            _growthPoint = 0;//成長ポイントをリセット
            _level = 0;//レベルをリセット
            _randomGrowthPoint = Calculator.RandomInt(_growth[0].MiniGrowthPoint, _growth[0].MaxGrowthPoint);
            //Random.Rangeをして必要なポイントを変えている
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
            _score.AddScore(_growth[_level].Point);//スコアを追加
            //Random.Rangeをして必要なポイントを変えている
            _randomGrowthPoint = Calculator.RandomInt(_growth[_level].MiniGrowthPoint, _growth[_level].MaxGrowthPoint);
            _level++;//レベルを上げる
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
        public int Point => _score;


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

        /// <summary>成長したときに貰えるスコア</summary>
        [SerializeField]
        [Header("成長したときに貰えるスコア")]
        int _score;
    }
}
