using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int CurrentScene;
    public int TurnIndex;

    private void Awake()
    {
        CurrentScene = 3;
        TurnIndex = 0;
    }
    public void ChangeScene()
    {
        TurnIndex = 0;
        //if (UIController.Instance.FadePannel != null)
        //{
        //    UIController.Instance.StartCoroutine("FadeInStart");
        //}
        SceneManager.LoadScene(CurrentScene);
    }
}
