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
    private void Update()
    {
        RoomTurnUpdate();
    }
    public void RoomTurnUpdate()
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
            if (roomInfo == RoomInfo.SOUND) // »ç¿îµå·ë¿¡ µé¾î°¬À» ¶§
            {
                AudioController.Instance.AudioStop();
                AudioController.Instance.AudioPlay(2);
            }

        }
    }
    void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Player")
        {
            AudioController.Instance.AudioStop();

            PlayerInRoom = false;
            AudioController.Instance.AudioPlay(0);
        }
    }
}
