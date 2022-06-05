using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkedaTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameManeger.Instance.GameStart());
    }

    // Update is called once per frame
    void Update()
    {
    }

}
