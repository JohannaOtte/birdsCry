using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_AdmonitionsText;
    [SerializeField] private List<Image> m_BirdImages;
    [SerializeField] private TextMeshProUGUI m_TimerText;

    private int m_CurrentBirdImage = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAdmonitions(int count)
    {
        m_AdmonitionsText.text = "Ermahnungen: " + count;
    }

    public void AddBird(Sprite bird)
    {
        if(m_CurrentBirdImage >= m_BirdImages.Count)
        {
            return;
        }

        m_BirdImages[m_CurrentBirdImage].color = Color.white;
        m_BirdImages[m_CurrentBirdImage].sprite = bird;
        m_CurrentBirdImage++;
    }

    public void SetTime(float m_TimeLeft)
    {
        int minutesLeft = (int) (m_TimeLeft / 60f);
        float secondsLeft = (int)(m_TimeLeft - minutesLeft*60);

        string minutesLeftAsString = minutesLeft.ToString();
        if(minutesLeftAsString.Length < 2)
        {
            minutesLeftAsString = "0" + minutesLeftAsString;
        }

        string secondsLeftAsString = secondsLeft.ToString();
        if (secondsLeftAsString.Length < 2)
        {
            secondsLeftAsString = "0" + secondsLeftAsString;
        }

        m_TimerText.text = minutesLeftAsString + ":" + secondsLeftAsString;
    }
}
