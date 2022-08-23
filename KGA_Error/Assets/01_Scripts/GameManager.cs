using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int CurrentScene { get; set; }
    private void Awake()
    {
        CurrentScene = 1;
    }
}
