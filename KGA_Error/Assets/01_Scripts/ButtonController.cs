using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ButtonController : MonoBehaviour
{   
    public bool doNotPush;

    public TextMeshPro checkingText; // 버튼 윗부분에 뜨는 텍스트
    public List<AudioClip> AudioList;
    
    AudioSource audioSource;

    private void Start()
    {
        doNotPush = false;

        AudioList = Resources.LoadAll("SE", typeof(AudioClip)).OfType<AudioClip>().ToList();
        audioSource = GetComponent<AudioSource>();
    }
    public void ButtonSoundPlay()
    {
        audioSource.PlayOneShot(AudioList[0], 1f);
    }
}
