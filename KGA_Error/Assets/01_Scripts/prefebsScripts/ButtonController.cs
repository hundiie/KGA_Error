using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonController : MonoBehaviour
{   
    public enum RoomInfo
    {
        Face = 1,
        Sound = 2,
        Moral = 3            
    }
    public RoomInfo roomInfo;

    public AudioSource buttonPlayer; // 버튼 눌리면 나는 소리
    public TextMeshPro checkingText; // 버튼 윗부분에 뜨는 텍스트
}
