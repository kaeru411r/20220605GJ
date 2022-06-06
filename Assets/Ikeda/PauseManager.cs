using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject _pauseCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManeger.Instance.Pause();
            if (GameManeger.Instance.IsPause)
            {
                _pauseCanvas.SetActive(true);
            }
            else
            {
                _pauseCanvas.SetActive(false);
            }
        }
    }
}
