using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MachineTriggerBehaviour : MonoBehaviour
{
    [SerializeField] private Color m_SelectedColor;
    [SerializeField] private Color m_DeactivatedColor;
    [SerializeField] private TextMeshProUGUI m_NameText;

    public enum MachineKind
    {
        GOOD,
        BAD,
        DEVASTATING,
        DEFAULT
    }

    [HideInInspector] public string m_MachineName = "DefaultMachine";
    [HideInInspector] public MachineKind m_MachineKind;

    private Color m_NormalColor;
    private bool m_IsDeactivated = false;

    // Start is called before the first frame update
    void Start()
    {
        m_NormalColor = GetComponent<MeshRenderer>().material.color;
    }

    public void Initialize(string machineName, MachineKind machineKind, AudioClip machineSound)
    {
        m_MachineName = machineName;
        m_MachineKind = machineKind;
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = machineSound;
        audioSource.loop = true;
        audioSource.Play();
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
            GetComponent<AudioSource>().Stop();
            m_IsDeactivated = true;
            return true;
        }

        return false;

    }

}
