using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    /// <summary>�Q�[���}�l�[�W���[�N���X�̃X�^�e�B�b�N�C���X�^���X</summary>
    static public SceneManager Instance;

    /// <summary>�^�C�g���V�[��</summary>
    int _titleScene = 0;
    /// <summary>�Q�[���V�[��</summary>
    int _gameScene = 1;
    /// <summary>���U���g�V�[��</summary>
    int _resultScene = 2;
    /// <summary>���݂̃V�[��</summary>
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
    /// �^�C�g���V�[�������[�h
    /// </summary>
    public void TitleScene()
    {
        SceneChange(_titleScene);
    }

    /// <summary>
    /// �Q�[���V�[�������[�h
    /// </summary>
    public void GameScene()
    {
        Debug.Log(_gameScene);
        SceneChange(_gameScene);
        StartCoroutine( GameManeger.Instance.GameStart());
    }

    /// <summary>
    /// ���U���g�V�[�������[�h
    /// </summary>
    public void ResultScene()
    {
        SceneChange(_resultScene);
    }

    /// <summary>
    /// ���݂̃V�[�������[�h
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
    /// �V�[�������[�h
    /// </summary>
    void SceneChange(int value)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(value);
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    }
}
