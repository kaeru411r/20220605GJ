using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger
{
    /// <summary>�Q�[���}�l�[�W���[�̃X�^�e�B�b�N�C���X�^���X</summary>
    static public GameManeger Instance = new GameManeger();

    /// <summary>
    /// �Q�[���X�^�[�g���ɌĂ�
    /// </summary>
    public IEnumerator GameStart()
    {
        yield return null;
        GameObject.FindObjectOfType<TimerScript>().TimerStart();
        var go = GameObject.FindObjectOfType<Generator>();
        go.GameStart();

        Debug.Log(go);
    }

    /// <summary>
    /// ���X�^�[�g���ɌĂ�
    /// </summary>
    public void GameRestart()
    {
        SceneManager.Instance.GameScene();
    }

    /// <summary>
    /// �Q�[���N���A���ɌĂ�
    /// </summary>
    public void GameClear()
    {
        SceneManager.Instance.ResultScene();
    }

    /// <summary>
    /// �Q�[���I�[�o�[���ɌĂ�
    /// </summary>
    public void GameOver()
    {
        SceneManager.Instance.ResultScene();
    }

    /// <summary>
    /// �Q�[���I�����ɌĂ�
    /// </summary>
    public void CloseApplication()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }

}
