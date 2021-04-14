using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera playerCam;
    [SerializeField]
    private CinemachineVirtualCamera startCam;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            startCam.Priority = startCam.Priority * -1;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    startCam.Priority = startCam.Priority * -1;
    //}
}
