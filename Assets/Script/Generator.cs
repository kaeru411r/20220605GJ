using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject fall;
    [SerializeField] float rightArea;
    [SerializeField] float leftArea;
    private bool isPlay;

    // Start is called before the first frame update
    void Start()
    {
        isPlay = false;
    }
    public void GameStart()
    {
        isPlay = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(isPlay)
        {
            float x = Random.Range(-8.0f,8.0f);
            float y = 5f;
        }
    }
}
