using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    /// <summary>�Q�[���}�l�[�W���[�N���X�̃X�^�e�B�b�N�C���X�^���X</summary>
    static public SceneManager Instance;

    /// <summary>�^�C�g���V�[��</summary>
    Scene _titleScene;
    /// <summary>�Q�[���V�[��</summary>
    Scene _gameScene;
    /// <summary>���U���g�V�[��</summary>
    Scene _resultScene;
    /// <summary>���݂̃V�[��</summary>
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
    /// �^�C�g���V�[�������[�h
    /// </summary>
    public void TitleScene()
    {
        SceneChange(_titleScene.buildIndex);
    }

    /// <summary>
    /// �Q�[���V�[�������[�h
    /// </summary>
    public void GameScene()
    {
        SceneChange(_gameScene.buildIndex);
        GameManeger.Instance.GameStart();
    }

    /// <summary>
    /// ���U���g�V�[�������[�h
    /// </summary>
    public void ResultScene()
    {
        SceneChange(_resultScene.buildIndex);
    }

    /// <summary>
    /// ���݂̃V�[�������[�h
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
    /// �V�[�������[�h
    /// </summary>
    void SceneChange(int value)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(value);
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }
}
