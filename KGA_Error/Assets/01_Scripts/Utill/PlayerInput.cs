using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInput : MonoBehaviour
{
    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )

    public float turnSpeed = 3f; // 마우스 회전 속도
    public float moveSpeed = 2f; // 이동 속도
                                 // public bool IsPush = false;
    public Transform CameraTransform;

    void Update()
    {
        MouseRotation();
        KeyboardMove();
        Raycast();
    }

    /// <summary>
    /// 마우스 회전으로 시야변경
    /// </summary>
    void MouseRotation()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);  // 회전량 제한(X축, 하늘방향, 바닥방향)

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }

    /// <summary>
    /// 이동과 이동속도
    /// </summary>
    void KeyboardMove()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0f;
        transform.position += (dir * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 3f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= 3f;
        }
    }

    /// <summary>
    /// 화면 가운데에 Ray쏘기
    /// </summary>
    void Raycast()
    {
        RaycastHit hit; // 충돌정보
        float maxDistance = 15f; // 검사 최대 거리

        // Debug.DrawRay(CameraTransform.position, CameraTransform.forward * maxDistance, Color.blue); // 레이쏘기

        if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out hit, maxDistance))
        {
            if (hit.transform.tag == "Button") // 버튼 감지하면
            {
                hit.transform.GetComponent<Button>()?.ButtonTextEnable(); // 버튼텍스트 출력
                if (Input.GetMouseButton(0)) // 클릭하면
                {
                    hit.transform.GetComponent<Button>().IsPush = true; // 눌렀다고 알려주기
                }
            }
        }
    }
}