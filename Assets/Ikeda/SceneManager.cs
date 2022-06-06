using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    /// <summary>ゲームマネージャークラスのスタティックインスタンス</summary>
    static public SceneManager Instance;

    /// <summary>タイトルシーン</summary>
    int _titleScene = 0;
    /// <summary>ゲームシーン</summary>
    int _gameScene = 1;
    /// <summary>リザルトシーン</summary>
    int _resultScene = 2;
    /// <summary>現在のシーン</summary>
    int _nowScene;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    
    private void Aw()
    {
    }

    /// <summary>
    /// タイトルシーンをロード
    /// </summary>
    public void TitleScene()
    {
        SceneChange(_titleScene);
    }

    /// <summary>
    /// ゲームシーンをロード
    /// </summary>
    public void GameScene()
    {
        Debug.Log(_gameScene);
        SceneChange(_gameScene);
        StartCoroutine( GameManeger.Instance.GameStart());
    }

    /// <summary>
    /// リザルトシーンをロード
    /// </summary>
    public void ResultScene()
    {
        SceneChange(_resultScene);
    }

    /// <summary>
    /// 現在のシーンをロード
    /// </summary>
    public void ReLoad()
    {
        if (_nowScene == _gameScene)
        {
            GameScene();
            return;
        }
        SceneChange(_nowScene);
    }

    /// <summary>
    /// シーンをロード
    /// </summary>
    void SceneChange(int value)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(value);
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    }
}
