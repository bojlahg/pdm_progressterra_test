using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform m_Camera;
    public float m_XSensitivity = 3, m_YSensitivity = 1;
    public float m_MoveVelocity = 1, m_RunVelocity = 2;
    //
    private float m_Yaw = 0, m_Pitch = 0;
    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveVelocity = m_MoveVelocity;
        if(Input.GetButton("Fire3")) // ��� (Left Shift)
        {
            moveVelocity = m_RunVelocity;
        }
       
        Vector3 velocity = m_Camera.forward * Input.GetAxis("Forward") + m_Camera.right * Input.GetAxis("Strafe") + Vector3.down * Input.GetAxis("Fly");

        m_Rigidbody.velocity = moveVelocity * velocity;

        // ��������
        m_Yaw = m_Yaw + m_XSensitivity * Input.GetAxis("Look Yaw");
        if(m_Yaw > 360)
        {
            m_Yaw -= 360;
        }
        else if (m_Yaw < -360)
        {
            m_Yaw += 360;
        }
        // ������
        m_Pitch = Mathf.Clamp(m_Pitch - m_YSensitivity * Input.GetAxis("Look Pitch"), -90, 90);

        m_Camera.transform.rotation = Quaternion.AngleAxis(m_Yaw, Vector3.up) * Quaternion.AngleAxis(m_Pitch, Vector3.right);
    }
}
