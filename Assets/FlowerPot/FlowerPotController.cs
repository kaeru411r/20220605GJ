using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPotController : MonoBehaviour
{
    /// <summary>成長度</summary>
    [SerializeField]
    [Header("成長度")]
    int _growth;

    /// <summary花の種類</summary>
    [SerializeField]
    [Header("花の種類")]
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
