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
        switch (sceneNumber)
        {
            case 0:
                SceneManager.LoadScene("Intro");
                break;
            case 1:
                SceneManager.LoadScene("Phase1");
                break;
        }
    }
}
