using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager m_UIManager;
    [SerializeField] private int m_NumberOfActiveMachines = 9;
    [SerializeField] private int m_NumberOfBadMachines = 3;
    [SerializeField] private int m_NumberOfBirds = 3;
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
        int machineNumber = UnityEngine.Random.Range(0,m_NumberOfActiveMachines);
        if (machineNumber < m_NumberOfBadMachines- GlobalVariables.ADMONITIONS)
        {
            GlobalVariables.ADMONITIONS++;
            m_UIManager.SetAdmonitions(GlobalVariables.ADMONITIONS);

            if(GlobalVariables.ADMONITIONS >= m_NumberOfBadMachines)
            {
                EndGame(GlobalVariables.GameState.LOST);
            }
        }

        m_NumberOfActiveMachines--;
    }

    public void BirdCatched()
    {
        GlobalVariables.SAVED_BIRDS++;
        m_UIManager.SetBirds(GlobalVariables.SAVED_BIRDS);
        if(GlobalVariables.SAVED_BIRDS >= m_NumberOfBirds)
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
