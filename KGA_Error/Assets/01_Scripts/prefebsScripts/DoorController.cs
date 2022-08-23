using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorController : MonoBehaviour
{
    private Animator doorAnim;  // 문열리는 애니메이션
    private bool isFindPlayer;  
    private float DoorAnimBlend;
    private TextMeshPro DoorTMP;   // 버튼 바로 위에 뜨는 텍스xm
    private string DoorText;   // 버튼 바로 위에 뜨는 텍스트

    public ButtonController buttonController;

    private void Awake()
    {
        doorAnim = GetComponentInChildren<Animator>();
        DoorTMP = GetComponentInChildren<TextMeshPro>();
        
    }

    private void Start()
    {
        DoorText = CSVParser.Instance.GetCsvDoorName(GameManager.Instance.CurrentScene, (int)buttonController.roomInfo);
        DoorTMP.text = DoorText;

        isFindPlayer = false;
    }

  

    private void Update()
    {
        if (isFindPlayer)
        {            
            DoorOpen();

            DoorAnimBlend += Time.deltaTime;
            if(DoorAnimBlend >= 1) { DoorAnimBlend = 1f; }
        }
        else
        {
            DoorClose();
            
            DoorAnimBlend -= Time.deltaTime;
            if (DoorAnimBlend <= 0) { DoorAnimBlend = 0f; }
        }
    }

    // 플레이어 감지
    void OnTriggerStay(Collider _other)
    {
        if (_other.tag == "Player") { isFindPlayer = true; }
    }
    void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Player") { isFindPlayer = false; }
    }

    // 문 열리는 애니메이션
    private void DoorOpen()
    {
        if (DoorAnimBlend <= 1) { doorAnim.SetFloat("Blend", DoorAnimBlend); }
    }
    private void DoorClose()
    {
        if (DoorAnimBlend >= 0) { doorAnim.SetFloat("Blend", DoorAnimBlend); }
    }
}