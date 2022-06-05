using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger
{
    /// <summary>ゲームマネージャーのスタティックインスタンス</summary>
    static public GameManeger Instance = new GameManeger();

    /// <summary>
    /// ゲームスタート時に呼ぶ
    /// </summary>
    public void GameStart()
    {
        GameObject.FindObjectOfType<TimerScript>().TimerStart();
    }

    /// <summary>
    /// リスタート時に呼ぶ
    /// </summary>
    public void GameRestart()
    {
        SceneManager.Instance.GameScene();
    }

    /// <summary>
    /// ゲームクリア時に呼ぶ
    /// </summary>
    public void GameClear()
    {
        SceneManager.Instance.ResultScene();
    }

    /// <summary>
    /// ゲームオーバー時に呼ぶ
    /// </summary>
    public void GameOver()
    {
        SceneManager.Instance.ResultScene();
    }

    /// <summary>
    /// ゲーム終了時に呼ぶ
    /// </summary>
    public void CloseApplication()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }

}
