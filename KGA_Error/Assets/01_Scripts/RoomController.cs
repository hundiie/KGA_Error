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

    public int[] MyTurn;
    // Start is called before the first frame update
    void Start()
    {
        MyTurn = CSVParser.Instance.GetCsvTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
