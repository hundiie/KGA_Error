using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private enum pushedInfo
    {
        First,
        Second,
        OneButton
    };
    private bool pushButton; // 버튼이 눌렸는지 확인
    private Animator buttonAmim; //  버튼 누르는 애니메이션
    private float buttonBlend;

    public AudioSource buttonPlayer; // 버튼 눌리면 나는 소리
    public PlayerInput Input; // 플레이어의 입력

    private void Awake()
    {
        buttonPlayer = GetComponent<AudioSource>();
        buttonAmim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.IsPush)
        {
            buttonBlend += Time.deltaTime;
            if (buttonBlend >= 1)
            {
                buttonBlend = 1f;
            }
            PushDown();
        }
        else if (!Input.IsPush)
        {
            buttonBlend -= Time.deltaTime;
            if (buttonBlend >= 0)
            {
                buttonBlend = 0f;
            }
            PushUp();
        }
    }
    private void PushDown()
    {
        if(Input.IsPush == true)
        {
            buttonAmim.SetFloat("Blend", buttonBlend);
        }
    }
    private void PushUp()
    {
        if (Input.IsPush == false)
        {
            buttonAmim.SetFloat("Blend", buttonBlend);
        }
    }

}
