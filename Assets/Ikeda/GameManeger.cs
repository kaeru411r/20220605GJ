using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger
{
    static public GameManeger Instance = new GameManeger();

    public void GameStart()
    {
        GameObject.FindObjectOfType<TimerScript>().TimerStart();
    }

    public void GameRestart()
    {

    }

    public void GameClear()
    {

    }

    public void GameOver()
    {

    }

    public void CloseApplication()
    {
        UnityEngine.Application.Quit();
    }

}
