using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraBehavior : MonoBehaviour
{
    public Camera[] m_Cameras;
    int cameraIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchCamera()
    {
        if(cameraIndex == m_Cameras.Length-1) 
        {
            cameraIndex = 0;
            m_Cameras[cameraIndex].enabled = true;
            m_Cameras[5].enabled = false;
        }
        else
        {
            cameraIndex++;
            m_Cameras[cameraIndex-1].enabled = false;
            m_Cameras[cameraIndex].enabled = true;

        }

    }
}
