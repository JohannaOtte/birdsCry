using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager m_UIManager;
    [SerializeField] private GameObject m_Player;

    [SerializeField] private List<MachineTriggerBehaviour> m_Machines;
    [SerializeField] private List<String> m_MachineDescriptions;
    [SerializeField] private List<MachineTriggerBehaviour.MachineKind> m_MachineKinds;
    [SerializeField] private List<AudioClip> m_MachineSounds;

    [SerializeField] private List<GameObject> m_BirdSpawnPoints;
    [SerializeField] private List<Sprite> m_BirdSprites;

    [SerializeField] private int m_MaxAdmonitions = 3;
    [SerializeField] private int m_NumberOfBirds = 3;

    [SerializeField] private float m_TimeLeft = 240f; //in seconds

    [SerializeField] private GameObject m_BirdPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InitializeMachines();
        InitializeBirds();
    }



    private void InitializeMachines()
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
            m_Machines[i].Initialize(m_MachineDescriptions[i], m_MachineKinds[i], m_MachineSounds[i]);
        }
    }

    private void InitializeBirds()
    {
        for (int i = 0; i < m_NumberOfBirds; i++)
        {
            int randomSpawnNo = -1;
            int randomSpriteNo = -1;

            if (m_BirdSpawnPoints.Count > 0)
            {
                randomSpawnNo = UnityEngine.Random.Range(0, m_BirdSpawnPoints.Count);
            }

            if (m_BirdSprites.Count > 0)
            {
                randomSpriteNo = UnityEngine.Random.Range(0, m_BirdSprites.Count);
            }

            GameObject spawnPoint = null;

            if(randomSpawnNo != -1)
            {
                spawnPoint = m_BirdSpawnPoints[randomSpawnNo];
                m_BirdSpawnPoints.RemoveAt(randomSpawnNo);
            }

            Sprite sprite = null;

            if (randomSpriteNo != -1)
            {
                sprite = m_BirdSprites[randomSpriteNo];
                m_BirdSprites.RemoveAt(randomSpriteNo);
            }

            if(spawnPoint != null)
            {
                Instantiate(m_BirdPrefab, spawnPoint.transform.position, Quaternion.identity);

                m_BirdPrefab.GetComponentInChildren<BirdBehaviour>().Initialize(sprite, m_Player.transform);
                
            }

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

    public void BirdCatched(GameObject bird)
    {
        GlobalVariables.SAVED_BIRDS++;
        Image birdImage = bird.GetComponentInChildren<Image>();
        if(birdImage != null)
        {
            m_UIManager.AddBird(birdImage.sprite);
        }
        
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
