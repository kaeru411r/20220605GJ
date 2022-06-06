using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GJ.Calculation;

public class FlowerPotController : MonoBehaviour
{
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

    [SerializeField]
    [Header("�v���C���[��Tag")]
    string _playerTag = "Player";

    /// <summary>�A�ؔ�</summary>
    [SerializeField]
    [Header("�A�ؔ�")]
    GameObject _flowerPot;

    [SerializeField]
    [Header("�y�̃X�v���C�g")]
    Sprite _soil;

    /// <summary>�A�ؔ���ς���N�[���_�E��</summary>
    [SerializeField]
    [Header("�A�ؔ���ς���N�[���_�E��")]
    float _interver = 0.1f;

    /// <summary>���͈̔�</summary>
    [SerializeField]
    [Header("���͈̔�")]
    float _leftArea = 8f;

    /// <summary>�E�͈̔�</summary>
    [SerializeField]
    [Header("�E�͈̔�")]
    float _rightArea = -8f;

    /// <summary>Y��</summary>
    [SerializeField]
    [Header("Y��")]
    float _yPos;

    /// <summary>�u���n�߂�ŏ��̈ʒu</summary>
    [SerializeField]
    [Header("�u���n�߂�ŏ��̈ʒu")]
    float _xPos = -6;

    /// <summary>��ʒu�ɒu���鐔�̌��E</summary>
    [SerializeField]
    [Header("��ʒu�ɒu���鐔�̌��E")]
    int _potCountLimit = 12;

    [SerializeField]
    [Header("��ʒu�ɒu���Ƃ��̐A�ؔ��̊Ԋu")]
    int _space = 2;

    /// <summary>�v���C���[</summary>
    GameObject _player;
    /// <summary>�X�R�A�̃X�N���v�g</summary>
    ScoreScript _score;
    /// <summary>���݂̉Ԃ̐������x��</summary>
    int _level;
    /// <summary>�����ɕK�v�ȃ����_���ȃ|�C���g</summary>
    int _randomGrowthPoint;
    /// <summary>�u�����A�ؔ��̐�</summary>
    int _potCount;
    /// <summary>��������</summary>
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
            //�N�[���_�E�����I�������
            ChengeFlowerPot();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.transform.IsChildOf(_player.transform))
        {
            //�J�ɐG�ꂽ��
            if (collision.gameObject.tag == _rainTag) Growth();
        }
    }

    /// <summary>�A�ؔ���ς���</summary>
    void ChengeFlowerPot()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //�u�����A�ؔ��̐������Ȃ�������
            if(_potCount < _potCountLimit)
            {
                Instantiate(_flowerPot, new Vector3(_xPos, _yPos, 10f), Quaternion.identity);
                _xPos += _space;
                _potCount++;
            }
            else
            {
                //�V�����A�ؔ��������_���Ȉʒu�ɐ���
                Instantiate(_flowerPot, new Vector3(Calculator.RandomFloat(_leftArea, _rightArea), _yPos, 10f), Quaternion.identity);
            }
            _flowerPos.sprite = _soil;//�y�ɕύX
            //�Ԃ��炢����X�R�A��ǉ�
            if (_level == _growth.Count - OFFSET - OFFSET || _level == _growth.Count - OFFSET)
            {
                _score.AddFlowerScore();
                //���X��������
                if(_level == _growth.Count - OFFSET)Generator.Instance.MoreRains();//�~���ʂ�ύX
            }
            //�͂ꂽ��
            if (_level == _growth.Count) Generator.Instance.RainsFactReset();//�~���ʂ����Z�b�g
            _growthPoint = 0;//�����|�C���g�����Z�b�g
            _level = 0;//���x�������Z�b�g
            _randomGrowthPoint = Calculator.RandomInt(_growth[0].MiniGrowthPoint, _growth[0].MaxGrowthPoint);
            //Random.Range�����ĕK�v�ȃ|�C���g��ς��Ă���
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
            _score.AddScore(_growth[_level].Point);//�X�R�A��ǉ�
            //Random.Range�����ĕK�v�ȃ|�C���g��ς��Ă���
            _randomGrowthPoint = Calculator.RandomInt(_growth[_level].MiniGrowthPoint, _growth[_level].MaxGrowthPoint);
            _level++;//���x�����グ��
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
        public int Point => _score;


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

        /// <summary>���������Ƃ��ɖႦ��X�R�A</summary>
        [SerializeField]
        [Header("���������Ƃ��ɖႦ��X�R�A")]
        int _score;
    }
}
