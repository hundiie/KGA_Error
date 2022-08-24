using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : SingletonBehaviour<SceneManagement>
{
    private int sceneNumber;
    public void ChangeScene()
    {
        sceneNumber = GameManager.Instance.CurrentScene;
        SceneManager.LoadScene(sceneNumber);
    }
}
