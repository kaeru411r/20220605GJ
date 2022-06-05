using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    /// <summary>ゲームマネージャークラスのスタティックインスタンス</summary>
    static public SceneManager Instance;

    /// <summary>タイトルシーン</summary>
    Scene _titleScene;
    /// <summary>ゲームシーン</summary>
    Scene _gameScene;
    /// <summary>リザルトシーン</summary>
    Scene _resultScene;
    /// <summary>現在のシーン</summary>
    Scene _nowScene;


    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _titleScene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(0);
        _gameScene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(1);
        _resultScene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(2);
    }

    /// <summary>
    /// タイトルシーンをロード
    /// </summary>
    public void TitleScene()
    {
        SceneChange(_titleScene.buildIndex);
    }

    /// <summary>
    /// ゲームシーンをロード
    /// </summary>
    public void GameScene()
    {
        SceneChange(_gameScene.buildIndex);
        GameManeger.Instance.GameStart();
    }

    /// <summary>
    /// リザルトシーンをロード
    /// </summary>
    public void ResultScene()
    {
        SceneChange(_resultScene.buildIndex);
    }

    /// <summary>
    /// 現在のシーンをロード
    /// </summary>
    public void ReLoad()
    {
        if(_nowScene == _gameScene)
        {
            GameScene();
            return;
        }
        SceneChange(_nowScene.buildIndex);
    }

    /// <summary>
    /// シーンをロード
    /// </summary>
    void SceneChange(int value)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(value);
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }
}
