using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Button : MonoBehaviour
{
    public bool IsPush = false; // 눌렸는지 체크

    private Animator buttonAmim;    // 버튼 누르는 애니메이션
    private float buttonBlend;      // 애니메이션 블랜드값
    private float timer;


    private ButtonController buttonController;

    public TextMeshPro ButtonText;   // 버튼 바로 위에 뜨는 텍스트


    private void Awake()
    {
        buttonController = GetComponentInParent<ButtonController>();
        buttonAmim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        if (buttonController.ButtonState == 0)
        {
            buttonController.checkingText.enabled = false;
        }
        ButtonText.enabled = false;
        buttonBlend = 0f;
    }
    private void Update()
    {
        if (IsPush)
        {
            StartCoroutine("PushDown");

            buttonBlend += Time.deltaTime; // 블랜드값 0 -> 1
            if (buttonBlend >= 1)
            {
                buttonBlend = 1f;
                IsPush = false; // 애니매이션이 끝나면 눌렸음 상태 변경
            }
        }
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            ButtonTextDisable();
            timer = 0f;
        }
    }

    /// <summary>
    /// 눌리는 애니메이션과 checking 텍스트 노출
    /// </summary>
    /// <returns>1초</returns>
    private IEnumerator PushDown()
    {
        if (IsPush == true)
        {
            buttonAmim.SetFloat("Blend", buttonBlend);
            yield return new WaitForSeconds(1f);
            buttonBlend = 0f; // 블랜드값 초기화
            if (buttonController.ButtonState == 0)
            {
                buttonController.checkingText.enabled = true; // 1초뒤에 checking텍스트 노출
            }
        }
    }

    public void ButtonTextEnable()
    {
        ButtonText.enabled = true;
    }
    public void ButtonTextDisable()
    {
        ButtonText.enabled = false;
    }
}
