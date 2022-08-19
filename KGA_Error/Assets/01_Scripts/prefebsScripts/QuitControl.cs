using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Player")
        {
            Debug.Log("³¡");
            Application.Quit();
        }
    }
}
