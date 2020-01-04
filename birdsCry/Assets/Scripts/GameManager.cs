using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager m_UIManager;

    [SerializeField] private List<MachineTriggerBehaviour> m_Machines;
    [SerializeField] private List<String> m_MachineDescriptions;
    [SerializeField] private List<MachineTriggerBehaviour.MachineKind> m_MachineKinds;
    [SerializeField] private List<AudioSource> m_MachineSounds;

    [SerializeField] private int m_MaxAdmonitions = 3;
    [SerializeField] private int m_NumberOfBirds = 3;

    [SerializeField] private float m_TimeLeft = 240f; //in seconds

    // Start is called before the first frame update
    void Start()
    {
        List<MachineTriggerBehaviour> sortedMachineList = new List<MachineTriggerBehaviour>();
        while (m_Machines.Count > 0)
        {
            int random = UnityEngine.Random.Range(0, m_Machines.Count);
            sortedMachineList.Add(m_Machines[random]);
            m_Machines.RemoveAt(random);
        }
        m_Machines = sortedMachineList;

        for (int i = 0; i < m_Machines.Count; i++)
        {
            m_Machines[i].Initialize(m_MachineDescriptions[i], m_MachineKinds[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SubtractTime();
    }

    private void SubtractTime()
    {
        m_TimeLeft -= Time.deltaTime;

        if ((int)m_TimeLeft <= 0)
        {
            EndGame(GlobalVariables.GameState.LOST);
        }

        m_UIManager.SetTime(m_TimeLeft);
    }

    public void MachineClicked(MachineTriggerBehaviour.MachineKind machineKind)
    {
        if (machineKind == MachineTriggerBehaviour.MachineKind.BAD)
        {
            GlobalVariables.ADMONITIONS++;
            if (GlobalVariables.ADMONITIONS >= m_MaxAdmonitions)
            {
                EndGame(GlobalVariables.GameState.LOST);
            }
            m_UIManager.SetAdmonitions(GlobalVariables.ADMONITIONS);
        }

        else if (machineKind == MachineTriggerBehaviour.MachineKind.DEVASTATING)
        {
            EndGame(GlobalVariables.GameState.LOST);
        }

        //OLD FOR RANDOM ADMONITIONS

        //int machineNumber = UnityEngine.Random.Range(0, m_NumberOfActiveMachines);
        //if (machineNumber < m_MaxAdmonitions - GlobalVariables.ADMONITIONS)
        //{
        //    GlobalVariables.ADMONITIONS++;
        //    m_UIManager.SetAdmonitions(GlobalVariables.ADMONITIONS);

        //    if (GlobalVariables.ADMONITIONS >= m_MaxAdmonitions)
        //    {
        //        EndGame(GlobalVariables.GameState.LOST);
        //    }
        //}

        //m_NumberOfActiveMachines--;
    }

    public void BirdCatched()
    {
        GlobalVariables.SAVED_BIRDS++;
        m_UIManager.SetBirds(GlobalVariables.SAVED_BIRDS);
        if (GlobalVariables.SAVED_BIRDS >= m_NumberOfBirds)
        {
            EndGame(GlobalVariables.GameState.WON);
        }
    }

    private void EndGame(GlobalVariables.GameState state)
    {
        GlobalVariables.GAMESTATE = state;
        SceneManager.LoadScene("EndScene");
    }
}
