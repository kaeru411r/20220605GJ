using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPotController : MonoBehaviour
{
    /// <summary>�����x</summary>
    [SerializeField]
    [Header("�����x")]
    int _growth;

    /// <summary�Ԃ̎��</summary>
    [SerializeField]
    [Header("�Ԃ̎��")]
    List<Sprite> _flower = new List<Sprite>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Growth();
    }

    void Growth()
    {
        _growth++;
    }
}
