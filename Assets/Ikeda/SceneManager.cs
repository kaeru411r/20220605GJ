using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    static public SceneManager Instance;

    Scene _titleScene;
    Scene _gameScene;
    Scene _resultScene;
    Scene _nowScene;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _titleScene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(0);
        _gameScene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(1);
        _resultScene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(2);
    }

    public void TitleScene()
    {
        SceneChange(_titleScene.buildIndex);
    }

    public void GameScene()
    {
        SceneChange(_gameScene.buildIndex);
    }

    public void ResultScene()
    {
        SceneChange(_resultScene.buildIndex);
    }

    public void ReLoad()
    {
        SceneChange(_nowScene.buildIndex);
    }

    void SceneChange(int value)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(value);
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }
}
