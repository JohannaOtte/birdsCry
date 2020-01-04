using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MachineTriggerBehaviour : MonoBehaviour
{
    [SerializeField] private string m_MachineName = "DefaultMachine";

    [SerializeField] private Color m_SelectedColor;
    [SerializeField] private Color m_DeactivatedColor;
    [SerializeField] private TextMeshProUGUI m_NameText;
    

    private Color m_NormalColor;
    private bool m_IsDeactivated = false;

    // Start is called before the first frame update
    void Start()
    {
        m_NormalColor = GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnSelected()
    {
        if (m_IsDeactivated)
        {
            return;
        }
        GetComponent<MeshRenderer>().material.color = m_SelectedColor;
        m_NameText.text = m_MachineName;
    }

    private void OnDeselected()
    {
        if (m_IsDeactivated)
        {
            return;
        }
        GetComponent<MeshRenderer>().material.color = m_NormalColor;
        m_NameText.text = "";
    }

    public bool OnClicked()
    {
        if (!m_IsDeactivated)
        {
            m_NameText.text = "DEACTIVATED";
            GetComponent<MeshRenderer>().material.color = m_DeactivatedColor;
            m_IsDeactivated = true;
            return true;
        }

        return false;
        
        
        
    }
}
