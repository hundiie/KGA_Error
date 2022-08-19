using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private void Awake()
    {
    }
    private void Start()
    {
    }
    void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Finish")
        {
            Application.Quit();
        }

    }
}
