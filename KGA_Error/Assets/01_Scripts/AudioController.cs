using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioController : SingletonBehaviour<AudioController>
{
    private AudioSource audioSource; // 파싱된 오디오 클립을 담을 오디오 소스
    
    public RoomController SoundRoom;
    public List<AudioClip> AudioList;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // 모든 오디오를 리스트에 담는다.
        AudioList = Resources.LoadAll("Audio", typeof(AudioClip)).OfType<AudioClip>().ToList();

        AudioPlay(0); // BGM으로 시작
    }

    public void AudioPlay(int _index)
    {
        audioSource.Stop();
        audioSource.clip = AudioList[CSVParser.Instance.GetCsvBGM(_index)];
        audioSource.Play();
    }
}
