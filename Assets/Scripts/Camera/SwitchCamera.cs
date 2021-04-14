using Cinemachine;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera playerCam;
    [SerializeField]
    private CinemachineVirtualCamera startingCam;

    private bool switchCams;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SwitchCameras();
        }
    }

    private void SwitchCameras()
    {
        startingCam.Priority = startingCam.Priority * -1;
    }
}
