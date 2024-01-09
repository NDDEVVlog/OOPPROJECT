using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private bool isPressing = false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            isPressing = true;
            virtualCamera.m_Lens.OrthographicSize = 3f;
        }
        else
        {
            isPressing = false;
            virtualCamera.m_Lens.OrthographicSize = 1.5f;
        }
    }
}
