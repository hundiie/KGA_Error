using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int CurrentPhase;
    void Start()
    {
        CurrentPhase = 0;
    }
    void Update()
    {
    }
    
}
