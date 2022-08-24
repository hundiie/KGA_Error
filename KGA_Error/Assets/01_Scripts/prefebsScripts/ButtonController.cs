using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonController : MonoBehaviour
{   
    public bool doNotPush;
    public TextMeshPro checkingText; // 버튼 윗부분에 뜨는 텍스트
    private void Start()
    {
        doNotPush = false;
    }
}
