using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int CurrentScene { get; set; }
    public int TurnIndex;

    private void Awake()
    {
        CurrentScene = 3;
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(CurrentScene);
        TurnIndex = 0;

    }
}
