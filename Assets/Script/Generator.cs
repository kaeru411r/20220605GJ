using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject fall;
    [SerializeField] float rightArea;
    [SerializeField] float leftArea;
    [SerializeField] float height;
    [SerializeField] float maxCT;
    float coolTime = 0;
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
            coolTime -= Time.deltaTime;
            if(coolTime <= 0)
            {
                float x = Random.Range(leftArea, rightArea);
                Instantiate(fall, new Vector3(x, height), Quaternion.identity);
                coolTime = Random.Range(0, maxCT);
            }
            
            
        }
    }
}