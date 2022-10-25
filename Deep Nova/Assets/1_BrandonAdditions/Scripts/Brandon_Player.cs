using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Brandon_Player : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera path0;
    [SerializeField] CinemachineVirtualCamera path1;
    [SerializeField] CinemachineVirtualCamera path2;
    [SerializeField] CinemachineVirtualCamera path3;

    private void OnEnable()
    {
        CameraSwitcher.Register(path0);
        CameraSwitcher.Register(path1);
        CameraSwitcher.Register(path2);
        CameraSwitcher.Register(path3);
    }
    private void OnDisable()
    {
        CameraSwitcher.Unregister(path0);
        CameraSwitcher.Unregister(path1);
        CameraSwitcher.Unregister(path2);
        CameraSwitcher.Unregister(path3);
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Switching Cameras to cam 0
            if (CameraSwitcher.IsActiveCamera(path1))
            {
                CameraSwitcher.SwitchCamera(path0);
            }else if(CameraSwitcher.IsActiveCamera(path2))
            {
                CameraSwitcher.SwitchCamera(path0);
            }else if (CameraSwitcher.IsActiveCamera(path3))
            {
                CameraSwitcher.SwitchCamera(path0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Switching Cameras to cam 1
            if (CameraSwitcher.IsActiveCamera(path0))
            {
                CameraSwitcher.SwitchCamera(path1);
            }
            else if (CameraSwitcher.IsActiveCamera(path2))
            {
                CameraSwitcher.SwitchCamera(path1);
            }
            else if (CameraSwitcher.IsActiveCamera(path3))
            {
                CameraSwitcher.SwitchCamera(path1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Switching Cameras to cam 2
            if (CameraSwitcher.IsActiveCamera(path0))
            {
                CameraSwitcher.SwitchCamera(path2);
            }
            else if (CameraSwitcher.IsActiveCamera(path1))
            {
                CameraSwitcher.SwitchCamera(path2);
            }
            else if (CameraSwitcher.IsActiveCamera(path3))
            {
                CameraSwitcher.SwitchCamera(path2);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Switching Cameras to cam 3
            if (CameraSwitcher.IsActiveCamera(path0))
            {
                CameraSwitcher.SwitchCamera(path3);
            }
            else if (CameraSwitcher.IsActiveCamera(path1))
            {
                CameraSwitcher.SwitchCamera(path3);
            }
            else if (CameraSwitcher.IsActiveCamera(path2))
            {
                CameraSwitcher.SwitchCamera(path3);
            }
        }
    }
}
