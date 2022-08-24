using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitControl : MonoBehaviour
{
    void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Player")
        {
            Debug.Log("³¡");
            Application.Quit();
        }
    }
}
