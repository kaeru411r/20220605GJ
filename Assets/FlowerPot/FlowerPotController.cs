using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPotController : MonoBehaviour
{
    /// <summary>ê¨í∑ìx</summary>
    [SerializeField]
    [Header("ê¨í∑ìx")]
    int _growth;

    /// <summaryâ‘ÇÃéÌóﬁ</summary>
    [SerializeField]
    [Header("â‘ÇÃéÌóﬁ")]
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
