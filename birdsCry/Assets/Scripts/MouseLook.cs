using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
   [SerializeField] private float m_MouseSensitivity = 100f;


   [SerializeField] private Transform m_PlayerTransform = null;
    private float m_XRotation = 0f;

    private GameObject m_CurrentSelection = null;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        Raycast();
    }


    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * m_MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * m_MouseSensitivity * Time.deltaTime;

        m_XRotation -= mouseY;
        m_XRotation = Mathf.Clamp(m_XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(m_XRotation, 0f, 0f);

        m_PlayerTransform.Rotate(Vector3.up * mouseX);

    }

    private void Raycast()
    {
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        GameObject selection = null;

        if (Physics.Raycast(ray, out hit))
        {
            selection = hit.collider.transform.gameObject;
            Debug.Log(selection);
            if(selection == m_CurrentSelection)
            {
                return;
            }



            if(selection != null && selection.tag == "MachineTrigger" || selection.tag == "Bird")
            {
                selection.SendMessageUpwards("OnSelected");
            }

            if (m_CurrentSelection != null && (m_CurrentSelection.tag == "MachineTrigger" || m_CurrentSelection.tag == "Bird"))
            {
                m_CurrentSelection.SendMessageUpwards("OnDeselected");
            }

            m_CurrentSelection = selection;

        }

        

       
    }
}
