using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OVR;

public class PlayerInput : MonoBehaviour
{
    private float xRotate = 0.0f; // ���� ����� X�� ȸ������ ���� ���� ( ī�޶� �� �Ʒ� ���� )

    public float turnSpeed = 2.5f; // ���콺 ȸ�� �ӵ�
    public float moveSpeed = 3f; // �̵� �ӵ�
    public Transform CameraTransform;

    void Update()
    {
      //  MouseRotation();
        KeyboardMove();
        Raycast();
    }

    /// <summary>
    /// ���콺 ȸ������ �þߺ���
    /// </summary>
    void MouseRotation()
    {
        float yRotateSize = 0;
        //float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        float xRotateSize = 0;
        //float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);  // ȸ���� ����(X��, �ϴù���, �ٴڹ���)

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }

    /// <summary>
    /// �̵��� �̵��ӵ�
    /// </summary>
    void KeyboardMove()
    {
        Vector2 mov2d = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        Vector3 dir = new Vector3(mov2d.x, 0, mov2d.y).normalized;

        // Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0f;
        transform.position += (dir * moveSpeed * Time.deltaTime);
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    moveSpeed *= 2f;
        //}
        //if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    moveSpeed /= 2f;
        //}
    }

    /// <summary>
    /// ȭ�� ����� Ray���
    /// </summary>
    void Raycast()
    {
        RaycastHit hit; // �浹����
        float maxDistance = 50f; // �˻� �ִ� �Ÿ�

        if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out hit, maxDistance))
        {
            if (hit.transform.tag == "Button") // ��ư �����ϸ�
            {
                hit.transform.GetComponent<Buttonss>()?.ButtonTextEnable(); // ��ư�ؽ�Ʈ ���
                if (Input.GetMouseButton(0) && !hit.transform.GetComponentInParent<ButtonController>().doNotPush) // Ŭ���ϸ�
                {
                    hit.transform.GetComponent<Buttonss>().IsPush = true; // �����ٰ� �˷��ֱ�
                }
                else if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && !hit.transform.GetComponentInParent<ButtonController>().doNotPush) // Ŭ���ϸ�
                {
                    hit.transform.GetComponent<Buttonss>().IsPush = true; // �����ٰ� �˷��ֱ�
                }
                
            }
        }
    }
}