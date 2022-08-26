using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorController : MonoBehaviour
{
    // 외부 스크립트
    private RoomController roomController;

    // 애니메이션
    private Animator doorAnim;  // 문열리는 애니메이션
    private float doorAnimBlend;
    private bool animFinish;
    private bool isFindPlayer;
    private bool doorLock;
    
    // 도어 텍스트
    private TextMeshPro doorTMP;
    private string doorText;

    private void Awake()
    {
        roomController = GetComponentInParent<RoomController>();
        doorAnim = GetComponentInChildren<Animator>();
        doorTMP = GetComponentInChildren<TextMeshPro>();
    }

    private void Start()
    {
        isFindPlayer = false;

        doorText = CSVParser.Instance.GetCsvDoorName((int)roomController.roomInfo);
        doorTMP.text = doorText;
        doorTMP.enabled = false;
    }

    private void Update()
    {
        // 플레이어가 방에 없고 내 턴도 아니고 애니메이션도 끝나있다면 문은 잠겨있음.
        if(!roomController.PlayerInRoom && !roomController.MyRoomTurn && animFinish)
        {
            doorLock = true;
            doorTMP.enabled = false;
        }
        else
        {
            doorLock = false;
            doorTMP.enabled = true;
        }

        if (!doorLock)
        {
            if (isFindPlayer)
            {
                DoorOpen();
                doorAnimBlend += Time.deltaTime;
                if (doorAnimBlend >= 1) { doorAnimBlend = 1f; }
            }
            else
            {
                DoorClose();

                doorAnimBlend -= Time.deltaTime;
                if (doorAnimBlend <= 0) { doorAnimBlend = 0f; animFinish = true; }
            }
        }
    }

    // 플레이어 감지
    void OnTriggerEnter(Collider _other)
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
        if (doorAnimBlend <= 1) { doorAnim.SetFloat("Blend", doorAnimBlend); animFinish = false; }
    }
    private void DoorClose()
    {
        if (doorAnimBlend >= 0) { doorAnim.SetFloat("Blend", doorAnimBlend); animFinish = false; }
    }
}