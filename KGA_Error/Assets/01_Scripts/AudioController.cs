using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioController : MonoBehaviour
{
    public RoomController SoundRoom;

    public List<AudioClip> AudioList;

    private int BGMIndex; // CSV에서 담긴 숫자
    private int soundRoomIndex; // CSV에서 담긴 숫자
    private AudioSource audioSource; // 파싱된 오디오 클립을 담을 오디오 소스
    void Start()
    {
        // 모든 이미지를 리스트에 담는다.
        AudioList = Resources.LoadAll("Audio", typeof(AudioClip)).OfType<AudioClip>().ToList();

        BGMIndex = CSVParser.Instance.GetCsvBGM(0);
        soundRoomIndex = CSVParser.Instance.GetCsvBGM(2);
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();
    }
    private void Update()
    {
        if (SoundRoom.PlayerInRoom)
        {
        //audioSource.Play();
            audioSource.clip = AudioList[soundRoomIndex];
        }
        else
        {
            audioSource.clip = AudioList[BGMIndex];
        //audioSource.Play();
        }
        // PlaySound();
    }
    //private void PlaySound()
    //{
    //}
}
