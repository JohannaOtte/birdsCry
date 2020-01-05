using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BirdBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_SaveText;

    [SerializeField] private Canvas m_OwnCanvas;

    [SerializeField] private Image m_Image;
    [SerializeField] private LookAtSomething m_LookAtSomething;

    private bool m_IsCatched = false;

    private GameObject m_FollowObject;

    // Update is called once per frame
    void Update()
    {
        FollowPlayerWhenCatched();
    }

    public void Initialize(Sprite sprite, Transform lookAtTarget)
    {
        Debug.Log(sprite);

        if (sprite != null)
        {
            m_Image.sprite = sprite;
        }
        m_LookAtSomething.m_IsInitialized = true;
        m_LookAtSomething.target = lookAtTarget;
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
