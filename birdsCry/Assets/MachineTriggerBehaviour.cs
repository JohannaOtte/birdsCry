using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTriggerBehaviour : MonoBehaviour
{
    [SerializeField] private Color m_SelectedColor;

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
    }

    private void OnDeselected()
    {
        GetComponent<MeshRenderer>().material.color = m_NormalColor;
    }
}
