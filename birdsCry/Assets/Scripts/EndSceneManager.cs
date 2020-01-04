using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_WinOrLoseText = null;
    [SerializeField] private TextMeshProUGUI m_SavedBirdsText = null;
    [SerializeField] private TextMeshProUGUI m_AdmonitionsText = null;

    [SerializeField] private string m_WinText = "Du hast gewonnen! AHU!";
    [SerializeField] private string m_LoseText = "Du hast verloren! BAM BAM BAAAA";

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        if(GlobalVariables.GAMESTATE == GlobalVariables.GameState.WON)
        {
            m_WinOrLoseText.text = m_WinText;
        }

        else
        {
            m_WinOrLoseText.text = m_LoseText;
        }

        m_SavedBirdsText.text = "Gerettete Vögel: " + GlobalVariables.SAVED_BIRDS;
        m_AdmonitionsText.text = "Ermahnungen: " + GlobalVariables.ADMONITIONS;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Replay()
    {
        SceneManager.LoadScene("MainScene");
    }
}
