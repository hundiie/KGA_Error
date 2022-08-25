using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public enum RoomInfo
    {
        LOBBY = 0,
        FACE = 1,
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
    public void RoomTurnChange()
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
    void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Player")
        {
            PlayerInRoom = true;
            if (roomInfo == RoomInfo.SOUND)
            {
                AudioController.Instance.PlaySound(CSVParser.Instance.GetCsvBGM(2), 0.1f);
            }

        }
    }
    void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Player")
        {
            PlayerInRoom = false;
            AudioController.Instance.PlaySound(CSVParser.Instance.GetCsvBGM(0), 0.1f);
        }
    }
}
