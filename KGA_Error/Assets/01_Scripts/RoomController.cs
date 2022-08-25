using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public enum RoomInfo
    {
        LOBBY = 0,
        FACE  = 1,
        SOUND = 2,
        MORAL = 3,
        CHECK = 4
    }
    public RoomInfo roomInfo;

    private int[] Turn;

    public bool MyRoomTurn;
    public bool PlayerInRoom;

    void Start()
    {
        Turn = CSVParser.Instance.GetCsvTurn();
        PlayerInRoom = false;
    }

    void Update()
    {
        if (Turn[GameManager.Instance.TurnIndex] == (int)roomInfo)
        {
            MyRoomTurn = true;
        }
        else
        {
            MyRoomTurn = false;
        }
    }
    void OnTriggerStay(Collider _other)
    {
        if (_other.tag == "Player") { PlayerInRoom = true; }
    }
    void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Player") { PlayerInRoom = false; }
    }
}
