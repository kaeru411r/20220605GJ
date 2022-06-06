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
    /// <summary>説明シーン</summary>
    int _informationScene = 1;
    /// <summary>ゲームシーン</summary>
    int _gameScene = 2;
    /// <summary>リザルトシーン</summary>
    int _resultScene = 3;
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

    private void Start()
    {
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
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
            Debug.Log(1);
            GameScene();
            return;
        }
        SceneChange(_nowScene);
    }

    /// <summary>
    /// 説明用のシーンをロード
    /// </summary>
    public void Information()
    {
        SceneChange(_informationScene);
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
