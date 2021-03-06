using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] float m_limitTime;
    Text m_timeText = default;
   
    bool _isPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        m_timeText = GetComponent<Text>();
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
        if (_isPlay)
        {
            m_limitTime -= Time.deltaTime;
            if(m_limitTime < 0)
            {
                GameManeger.Instance.GameClear();
            }
        }
        m_timeText.text = m_limitTime.ToString("F2");
    }


    public void TimerStart()
    {
        _isPlay = true;
    }

    public void OnPause()
    {
        _isPlay = false;
    }

    public void OnResume()
    {
        _isPlay = true;
    }
}
