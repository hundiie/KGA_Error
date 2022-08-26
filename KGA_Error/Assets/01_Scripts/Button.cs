using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Button : MonoBehaviour
{
    public enum ButtonInfo  // 버튼 종류
    {
        OneButton,
        TwoButton_L,
        TwoButton_R,
    };
    public ButtonInfo ButtonState;

    public bool IsPush = false; // 눌렸는지 체크

    private RoomController roomController;
    private ButtonController buttonController;
    private AudioSource buttonPlayer;   // 버튼 누르면 나는 소리

    private Animator buttonAmim;    // 버튼 누르는 애니메이션
    private string ButtonText;      // CSV에서 가져오는 텍스트
    private TextMeshPro ButtonTMP;  // 버튼 바로 위에 뜨는 텍스트

    private float buttonBlend;      // 애니메이션 블랜드값
    private float timer;

    private void Awake()
    {
        roomController = GetComponentInParent<RoomController>();
        buttonController = GetComponentInParent<ButtonController>();
        buttonAmim = GetComponent<Animator>();
        ButtonTMP = GetComponentInChildren<TextMeshPro>();
    }

    private void Start()
    {
        // 버튼 텍스트 파싱
        switch ((int)ButtonState)
        {
            case 0: // 한개버튼
                ButtonText = CSVParser.Instance.GetCsvOneButton((int)roomController.roomInfo);
                buttonController.checkingText.enabled = false;
                break;
            case 1: // 왼쪽버튼
                ButtonText = CSVParser.Instance.GetCsvTwoButton_L((int)roomController.roomInfo);
                break;
            case 2: // 오른쪽 버튼
                ButtonText = CSVParser.Instance.GetCsvTwoButton_R((int)roomController.roomInfo);
                break;
        }
        ButtonTMP.text = ButtonText;
        ButtonTMP.enabled = false;

        buttonBlend = 0f;
    }
    private void Update()
    {
        if (IsPush)
        {
            StartCoroutine("PushDown");
            float blendSpeed = Time.deltaTime * 1.5f;
            buttonBlend += blendSpeed; // 블랜드값 0 -> 1
        }

        // 플레이어 주시에 따른 버튼 텍스트 관련
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
        buttonController.doNotPush = true;
        buttonAmim.SetFloat("Blend", buttonBlend);

        // 버튼 하나일 때만 checking텍스트 노출
        if (ButtonState == 0) { buttonController.checkingText.enabled = true; }

        if (buttonBlend >= 1)
        {
            IsPush = false; // 애니매이션이 끝나면 눌렸음 상태 변경
            buttonBlend = 0f;

            yield return null;
            buttonController.ButtonSoundPlay();

            yield return new WaitForSeconds(3f);
            if (ButtonState == 0)
            {
                GameManager.Instance.CurrentScene++;
                GameManager.Instance.UpdateScene();
            }
            else
            {
                GameManager.Instance.TurnIndex++;
                roomController.RoomTurnUpdate();
            }
            StopCoroutine("PushDown");
        }
    }
    public void ButtonTextEnable()
    {
        ButtonTMP.enabled = true;
    }
    public void ButtonTextDisable()
    {
        ButtonTMP.enabled = false;
    }
}
