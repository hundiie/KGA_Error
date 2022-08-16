using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float turnSpeed = 4.0f; // 마우스 회전 속도
    public float moveSpeed = 2.0f; // 이동 속도

    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )
    
    void Update ()
    {
        MouseRotation();
        KeyboardMove();
    }
    
    void MouseRotation()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;        
        float yRotate = transform.eulerAngles.y + yRotateSize;
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);  // 회전량 제한(X축, 하늘방향, 바닥방향)

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }
    
    void KeyboardMove()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(dir * moveSpeed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 3f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= 3f;
        }
    }
}