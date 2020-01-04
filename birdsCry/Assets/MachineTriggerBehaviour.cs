using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MachineTriggerBehaviour : MonoBehaviour
{
    [SerializeField] private string m_MachineName = "DefaultMachine";

    [SerializeField] private Color m_SelectedColor;
    [SerializeField] private TextMeshProUGUI m_NameText;


    private Color m_NormalColor;

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
        GetComponent<MeshRenderer>().material.color = m_SelectedColor;
        m_NameText.text = m_MachineName;
    }

    private void OnDeselected()
    {
        GetComponent<MeshRenderer>().material.color = m_NormalColor;
        m_NameText.text = "";
    }
}
