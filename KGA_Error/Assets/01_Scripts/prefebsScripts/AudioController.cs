using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioController : MonoBehaviour
{
    public List<AudioClip> AudioList;

    private int audioIndex; // CSV에서 담긴 숫자
    private AudioSource audioSource; // 파싱된 오디오 클립을 담을 오디오 소스

    void Start()
    {
        // 모든 이미지를 리스트에 담는다.
        AudioList = Resources.LoadAll("Audio", typeof(AudioClip)).OfType<AudioClip>().ToList();

        audioIndex = CSVParser.Instance.GetCsvBGM();

        PlaySound(audioIndex);
    }
    private void PlaySound(int _index)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = AudioList[_index];
        audioSource.Play();
    }
}
