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
        CurrentScene = 9;
        TurnIndex = 0;
    }
    public void ChangeScene()
    {
        TurnIndex = 0;
        //if (UIController.Instance.FadePannel != null)
        //{
        //    UIController.Instance.StartCoroutine("FadeInStart");
        //}
        AudioController.Instance.PlaySound(CSVParser.Instance.GetCsvBGM(0), 0.1f);
        SceneManager.LoadScene(CurrentScene);
    }
}
