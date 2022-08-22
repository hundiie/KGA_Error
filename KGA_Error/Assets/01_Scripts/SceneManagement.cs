using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private int sceneNumber;
    void Update()
    {
        sceneNumber = GameManager.Instance.CurrentPhase;
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
