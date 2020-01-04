using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtSomething : MonoBehaviour
{

    public Transform target;
    public bool m_IsInitialized = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_IsInitialized)
        {
            return;
        }
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z)); 
    }
}
