using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour
{
    [SerializeField] private Image m_Image;
    [SerializeField] private List<Sprite> m_Sprites;

    [SerializeField] private Button m_FirstContinueButton;
    [SerializeField] private Button m_SecondContinueButton;
    // Start is called before the first frame update
    void Start()
    {
        if (m_Sprites.Count > 0)
        {
            m_Image.sprite = m_Sprites[0];
            m_Sprites.RemoveAt(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        if(m_Sprites.Count > 0)
        {
            m_Image.sprite = m_Sprites[0];

            if(m_Sprites.Count <= 3)
            {
                m_FirstContinueButton.gameObject.SetActive(false);
                m_SecondContinueButton.gameObject.SetActive(true);
            }

            m_Sprites.RemoveAt(0);


        }

        else
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
