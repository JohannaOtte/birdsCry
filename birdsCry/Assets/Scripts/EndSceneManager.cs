using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_WinOrLoseText = null;
    [SerializeField] private TextMeshProUGUI m_SavedBirdsText = null;
    [SerializeField] private TextMeshProUGUI m_AdmonitionsText = null;

    [SerializeField] private string m_WinText = "Du hast gewonnen! AHU!";
    [SerializeField] private string m_LoseText = "Du hast verloren! BAM BAM BAAAA";

    [SerializeField] private Image m_BackgroundImage;
    [SerializeField] private Sprite m_WinSprite;
    [SerializeField] private Sprite m_LoseSprite;

    [SerializeField] private Camera m_Camera;
    [SerializeField] private Color m_WinBackgroundColor;
    [SerializeField] private Color m_LoseBackgroundColor;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        if(GlobalVariables.GAMESTATE == GlobalVariables.GameState.WON)
        {
            m_WinOrLoseText.text = m_WinText;
            m_BackgroundImage.sprite = m_WinSprite;
            m_Camera.backgroundColor = m_WinBackgroundColor;
        }

        else
        {
            m_WinOrLoseText.text = m_LoseText;
            m_BackgroundImage.sprite = m_LoseSprite;
            m_Camera.backgroundColor = m_LoseBackgroundColor;
        }

        m_BackgroundImage.preserveAspect = true;

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
