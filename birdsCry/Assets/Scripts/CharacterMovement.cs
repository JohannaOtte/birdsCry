using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private bool m_RawInput = false;
    [SerializeField] private float m_Speed = 12f;
    [SerializeField] private float m_Gravity = -9.81f;

    [SerializeField] private GameObject m_Body;

    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private float m_GroundDistance = 0.4f;
    [SerializeField] private LayerMask m_GroundMask;

    private CharacterController m_Controller = null;

    public Vector3 m_Velocity;
    public bool m_IsGrounded = false;



    private void Start()
    {
        m_Controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CheckIfGrounded();
        Move();
        StickToGround();

    }

    private void CheckIfGrounded()
    {
        m_IsGrounded = Physics.CheckSphere(m_GroundCheck.position, m_GroundDistance, m_GroundMask);

        if (m_IsGrounded)
        {
            m_Velocity.y = -2;
        }
    }



    private void Move()
    {


        float x = -1;
        float z = -1;

        if (m_RawInput)
        {
            x = Input.GetAxisRaw("Horizontal");
            z = Input.GetAxisRaw("Vertical");
        }

        else
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }

        Vector3 move = transform.right * x + transform.forward * z;

        m_Controller.Move(move * m_Speed * Time.deltaTime);
    }

    private void StickToGround()
    {
        if (!m_IsGrounded)
        {
            m_Velocity.y += m_Gravity + Time.deltaTime;
        }

        m_Controller.Move(m_Velocity * Time.deltaTime);
    }
}
