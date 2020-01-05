using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour
{
    [SerializeField] private Image m_Image;
    [SerializeField] private List<Sprite> m_Sprites;
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
            m_Sprites.RemoveAt(0);
        }

        else
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
