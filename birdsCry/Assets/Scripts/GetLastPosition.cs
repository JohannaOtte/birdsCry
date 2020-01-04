using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLastPosition : MonoBehaviour
{
    [SerializeField] private GameObject m_PosObject;
    [SerializeField] private float m_TimeSinceLastPos = 0.5f;
    private Vector3 m_LastFollowObjPos;
    private float m_LastFollowObjPosTimeCount = 0;

    public Vector3 GetLastPos()
    {
        return m_LastFollowObjPos;
    }

    // Update is called once per frame
    void Update()
    {
        m_LastFollowObjPosTimeCount += Time.deltaTime;

        if (m_LastFollowObjPosTimeCount >= m_TimeSinceLastPos)
        {
            m_LastFollowObjPosTimeCount = 0;
            m_LastFollowObjPos = m_PosObject.transform.position;
        }
    }
}
