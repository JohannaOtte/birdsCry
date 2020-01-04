using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager m_UIManager;
    [SerializeField] private int m_NumberOfActiveMachines = 9;
    [SerializeField] private int m_NumberOfBadMachines = 3;
    private int m_NumberOfAdmonitions = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MachineClicked()
    {
        int machineNumber = Random.Range(0,m_NumberOfActiveMachines);
        if (machineNumber < m_NumberOfBadMachines-m_NumberOfAdmonitions)
        {
            m_NumberOfAdmonitions++;
            m_UIManager.SetAdmonitions(m_NumberOfAdmonitions);
        }

        m_NumberOfActiveMachines--;
    }
}
