using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int CurrentScene { get; set; }
    private void Awake()
    {
        CurrentScene = 1;
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(CurrentScene);
    }
}
