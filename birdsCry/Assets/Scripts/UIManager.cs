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

    [SerializeField] private Color m_FirstWarningColor;
    [SerializeField] private Color m_SecondWarningColor;
    [SerializeField] private Color m_ThirdWarningColor;

    private int m_CurrentBirdImage = 0;

    public void SetAdmonitions(int count)
    {
        m_AdmonitionsText.text = "Ermahnungen: " + count;
        //CHANGE COLOR
        // switch (count)
        //{
        //    case 1:
        //        m_AdmonitionsText.faceColor = m_FirstWarningColor;
        //        break;
        //    case 2:
        //        m_AdmonitionsText.faceColor = m_SecondWarningColor;
        //        break;
        //    case 3:
        //        m_AdmonitionsText.faceColor = m_ThirdWarningColor;
        //        break;
        //    default:
        //        break;
        //}
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
