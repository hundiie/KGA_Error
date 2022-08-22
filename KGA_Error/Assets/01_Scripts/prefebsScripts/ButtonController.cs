using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonController : MonoBehaviour
{
    public AudioSource buttonPlayer; // 버튼 눌리면 나는 소리
    public TextMeshPro checkingText; // 버튼 윗부분에 뜨는 텍스트

    public enum ButtonInfo // 버튼 상태 관련(아직 안썼음)
    {
        OneButton,
        TwoButton
    };
    public ButtonInfo ButtonState;

}
