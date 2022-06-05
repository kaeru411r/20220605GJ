using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GJ.Calculation;

public class FlowerPotController : MonoBehaviour
{
    ///// <summary>�X�R�A�̃v���p�e�B</summary>
    //public int Score => _score;

    /// <summary>��������̂ɕK�v�Ȃ���</summary>
    [SerializeField]
    [Header("��������̂ɕK�v�Ȃ���")]
    List<GrowthPointLimit> _growth = new List<GrowthPointLimit>();

    /// <summary>���݂̐����|�C���g</summary>
    [SerializeField]
    [Header("���݂̐����|�C���g")]
    int _growthPoint;

    /// <summary>�Ԃ𐶐�����ʒu</summary>
    [SerializeField]
    [Header("�Ԃ𐶐�����ʒu")]
    SpriteRenderer _flowerPos;

    /// <summary>�J��Tag</summary>
    [SerializeField]
    [Header("�J��Tag")]
    string _rainTag;

    /// <summary>�y�̃X�v���C�g</summary>
    [SerializeField]
    [Header("�y�̃X�v���C�g")]
    Sprite _soil;

    /// <summary>�A�ؔ�</summary>
    [SerializeField]
    [Header("�A�ؔ�")]
    GameObject _flowerPotPrefab;

    [SerializeField]
    [Header("�A�ؔ���ς���N�[���_�E��")]
    float _interver = 0.1f;

    /// <summary>���݂̉Ԃ̐������x��</summary>
    int _level;
    /// <summary>�����ɕK�v�ȃ����_���ȃ|�C���g</summary>
    int _randomGrowthPoint;
    /// <summary>��������</summary>
    const int OFFSET = 1;
    ///// <summary>�X�R�A</summary>
    //int _score;

    float _timer;

    void Start()
    {
        //Random.Range�����ĕK�v�ȃ|�C���g��ς��Ă���
        _randomGrowthPoint = Calculator.RandomNumber(_growth[0].MiniGrowthPoint, _growth[0].MaxGrowthPoint);
    }

    void Update()
    {
        _timer += Time.deltaTime;
        //�N�[���_�E�����I�������
        if(_timer > _interver)ChengeFlowerPot();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //�J�ɐG�ꂽ��
        //if (collision.gameObject.tag == _rainTag) Growth();
        Growth();     
    }

    /// <summary>�A�ؔ���ς���</summary>
    void ChengeFlowerPot()
    {
        if (Input.GetButton("Jump"))
        {          
            //_score += _growthPointLimit[_level].ManyPoint;//�X�R�A��ǉ�
            _growthPoint = 0;//�����|�C���g�����Z�b�g���Z�b�g
            _level = 0;//���x�������Z�b�g
            _flowerPos.sprite = _soil;//�y�ɖ߂�
            //Random.Range�����Đ����ɕK�v�ȃ|�C���g��ς��Ă���
            _randomGrowthPoint = Calculator.RandomNumber(_growth[0].MiniGrowthPoint, _growth[0].MaxGrowthPoint);
            _timer = 0;
        }
    }

    //�Ԃ𐬒�������
    void Growth()
    {
        _growthPoint++;

        //�K�v�Ȑ����|�C���g�܂ŒB������
        if (_growthPoint >= _randomGrowthPoint && _level < _growth.Count)
        {
            _flowerPos.sprite = _growth[_level].Flower;//�X�v���C�g��ύX
            //_score += _growthPointLimit[_level].Point;//�X�R�A��ǉ�        
            _randomGrowthPoint = Calculator.RandomNumber(_growth[_level].MiniGrowthPoint, _growth[_level].MaxGrowthPoint);
            if(_level < _growth.Count - OFFSET)_level++;//���x�����グ��
        }
    }

    /// <summary>��������̂ɕK�v�ȃ|�C���g�Ɛ����p�̉Ԃ�ݒ肷��</summary>
    [Serializable]
    public class GrowthPointLimit
    {
        /// <summary>���̏�Ԃɐ�������̂ɕK�v�ȍŏ��|�C���g�̃v���p�e�B</summary>
        public int MiniGrowthPoint  => _miniGrowthPoint;
        /// <summary>���̏�Ԃɐ�������̂ɕK�v�ȍő�|�C���g�̃v���p�e�B</summary>
        public int MaxGrowthPoint => _maxGrowthPoint;
        /// <summary>�Ԃ̃X�v���C�g�̃v���p�e�B</summary>
        public Sprite Flower => _flower;
        /// <summary>���������Ƃ��ɖႦ��X�R�A�̃v���p�e�B<summary>
        //public int Point => _score;
        ///// <summary>�A�ؔ���ς����Ƃ��ɖႦ���ʂ̃X�R�A�̃v���p�e�B</summary>
        //public int ManyPoint  => _manyScore;


        /// <summary>���x��</summary>
        [SerializeField]
        [Header("���x��")]
        string _level;

        /// <summary>���̏�Ԃɐ�������̂ɕK�v�ȍŏ��|�C���g</summary>
        [SerializeField]
        [Header("���̏�Ԃɐ�������̂ɕK�v�ȍŏ��|�C���g")]
        int _miniGrowthPoint;

        /// <summary>���̏�Ԃɐ�������̂ɕK�v�ȍő�|�C���g</summary>
        [SerializeField]
        [Header("���̏�Ԃɐ�������̂ɕK�v�ȍő�|�C���g")]
        int _maxGrowthPoint;

        /// <summary>�Ԃ̃X�v���C�g</summary>
        [SerializeField]
        [Header("�Ԃ̃X�v���C�g")]
        Sprite _flower;

        ///// <summary>���������Ƃ��ɖႦ��X�R�A</summary>
        //[SerializeField]
        //[Header("���������Ƃ��ɖႦ��X�R�A")]
        //int _score;

        ///// <summary>�A�ؔ���ς����Ƃ��ɖႦ���ʂ̃X�R�A</summary>
        //[SerializeField]
        //[Header("�A�ؔ���ς����Ƃ��ɖႦ���ʂ̃X�R�A")]
        //int _manyScore;
    }
}
