using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    static Generator _instance;
    public static Generator Instance { get { return _instance; } }

    [SerializeField] GameObject fall;
    [SerializeField] float rightArea;
    [SerializeField] float leftArea;
    [SerializeField] float height;
    [SerializeField] float maxCT;
    [SerializeField] float moreRainFact;

    float rainsFact = 1;
    float coolTime = 0;
    private bool isPlay;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    public void GameStart()
    {
        isPlay = true;
    }

    private void OnEnable()
    {
        GameManeger.Instance._OnPause += OnPause;
        GameManeger.Instance._OnResume += OnResume;
    }

    private void OnDisable()
    {
        GameManeger.Instance._OnPause -= OnPause;
        GameManeger.Instance._OnResume -= OnResume;
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
                coolTime = Random.Range(0, maxCT * rainsFact);
            }
            
            
        }
    }

    public void OnPause()
    {
        isPlay=false;
    }

    public void OnResume()
    {
        isPlay = true;
    }

    public void MoreRains()
    {
        rainsFact /= moreRainFact;
    }

    public void RainsFactReset()
    {
        rainsFact = 1;
    }
}
