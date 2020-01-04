using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_SaveText;

    [SerializeField] private Canvas m_OwnCanvas;

    private bool m_IsCatched = false;

    private GameObject m_FollowObject;

    // Update is called once per frame
    void Update()
    {
        FollowPlayerWhenCatched();
    }



    private void OnSelected()
    {
        if (m_IsCatched)
        {
            return;
        }
        m_SaveText.text = "Rette den Vogel!";
    }

    private void OnDeselected()
    {
        if (m_IsCatched)
        {
            return;
        }
        m_SaveText.text = "";
    }

    public bool OnClicked(GameObject followObject)
    {
        if (m_IsCatched)
        {
            return false;
        }
        m_FollowObject = followObject;
        m_IsCatched = true;
        m_SaveText.text = "";
        GetComponent<AudioSource>().Stop();
        return true;
    }

    private void FollowPlayerWhenCatched()
    {
        if (!m_IsCatched)
        {
            return;
        }



        m_OwnCanvas.transform.position =  m_FollowObject.GetComponent<GetLastPosition>().GetLastPos();

    }


}
