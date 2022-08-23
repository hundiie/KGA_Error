using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Button : MonoBehaviour
{
    public enum ButtonInfo // 버튼 상태 관련(아직 안썼음)
    {
        OneButton,
        TwoButton_L,
        TwoButton_R,
    };
    public ButtonInfo ButtonState;

    public bool IsPush = false; // 눌렸는지 체크

    private ButtonController buttonController;
    private Animator buttonAmim;    // 버튼 누르는 애니메이션
    private TextMeshPro ButtonTMP;   // 버튼 바로 위에 뜨는 텍스트
    private string ButtonText;   // 버튼 바로 위에 뜨는 텍스트

    private float buttonBlend;      // 애니메이션 블랜드값
    private float timer;

    private void Awake()
    {
        buttonController = GetComponentInParent<ButtonController>();
        buttonAmim = GetComponent<Animator>();
        ButtonTMP = GetComponentInChildren<TextMeshPro>();
    }
    private void Start()
    {

        switch ((int)ButtonState)
        {
            case 1: // 왼쪽버튼
                ButtonText = CSVParser.Instance.GetCsvB1(GameManager.Instance.CurrentScene, (int)buttonController.roomInfo);
                break;
            case 2: // 오른쪽 버튼
                ButtonText = CSVParser.Instance.GetCsvB2(GameManager.Instance.CurrentScene, (int)buttonController.roomInfo);
                break;
        }
        ButtonTMP.text = ButtonText;
        Debug.Log(gameObject.name + $" - buttonController.roomInfo : {buttonController.roomInfo}, ButtonState : {ButtonState} ButtonText: {ButtonText}, currentScene : {GameManager.Instance.CurrentScene}");

        if (ButtonState == 0)
        {
            buttonController.checkingText.enabled = false;
        }
        ButtonTMP.enabled = false;
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
            if (ButtonState == 0)
            {
                buttonController.checkingText.enabled = true; // checking텍스트 노출
            }
            yield return new WaitForSeconds(4f);
            buttonBlend = 0f; // 블랜드값 초기화
            if (ButtonState == 0)
            {
                Debug.Log($"currentScene : {GameManager.Instance.CurrentScene}");
                GameManager.Instance.CurrentScene++; // 씬넘어감
                Debug.Log($"currentScene : {GameManager.Instance.CurrentScene}");
                SceneManagement.Instance.ChangeScene();
            }
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
