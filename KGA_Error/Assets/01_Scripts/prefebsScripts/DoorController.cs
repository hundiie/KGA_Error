using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorController : MonoBehaviour
{
    private RoomController roomController;

    private TextMeshPro doorTMP;
    private string doorText;

    private Animator doorAnim;  // 문열리는 애니메이션
    private float doorAnimBlend;

    private bool isFindPlayer;

    private void Awake()
    {
        roomController = GetComponentInParent<RoomController>();
        doorTMP = GetComponentInChildren<TextMeshPro>();
        doorAnim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        doorText = CSVParser.Instance.GetCsvDoorName((int)roomController.roomInfo);
        doorTMP.text = doorText;

        isFindPlayer = false;
    }

    private void Update()
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
            if (doorAnimBlend <= 0) { doorAnimBlend = 0f; }
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
        if (doorAnimBlend <= 1) { doorAnim.SetFloat("Blend", doorAnimBlend); }
    }
    private void DoorClose()
    {
        if (doorAnimBlend >= 0) { doorAnim.SetFloat("Blend", doorAnimBlend); }
    }
}