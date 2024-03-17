using UnityEngine;
using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;

using BehaviorTree;
public class CameraSwitchTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera switchCamera;
    private CinemachineVirtualCamera originalCamera;

    
    private void Start()
    {
//        originalCamera = CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
            switchCamera = GetComponent<CinemachineVirtualCamera>();
            originalCamera = GameObject.FindGameObjectWithTag("MainCineCamera").GetComponent<CinemachineVirtualCamera>();

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SwitchCameraSmooth(switchCamera);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SwitchCameraSmooth(originalCamera);
        }
    }

    private void SwitchCameraSmooth(CinemachineVirtualCamera newCamera)
    {
        CinemachineBrain cinemachineBrain = CinemachineCore.Instance.GetActiveBrain(0);

        // Define a blend between the current camera and the new camera
        CinemachineBlendDefinition blend = new CinemachineBlendDefinition();
        blend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
        blend.m_Time = 1.0f;

        // Perform the blend
        cinemachineBrain.m_DefaultBlend = blend;

        // Switch cameras
        cinemachineBrain.ActiveVirtualCamera.Priority = 0;
        newCamera.Priority = 10;

        // Get the transposer of both cameras
        CinemachineTransposer originalTransposer = originalCamera.GetCinemachineComponent<CinemachineTransposer>();
        CinemachineTransposer newTransposer = switchCamera.GetCinemachineComponent<CinemachineTransposer>();

        // Interpolate between the orbital transposer values
        StartCoroutine(InterpolateOrbitalTransposer(originalTransposer, newTransposer));
    }

    private IEnumerator InterpolateOrbitalTransposer(CinemachineTransposer fromTransposer, CinemachineTransposer toTransposer)
    {
        float elapsedTime = 0f;
        float duration = 1.0f; // Adjust the duration as needed

        while (elapsedTime < duration)
        {
            fromTransposer.m_FollowOffset = Vector3.Lerp(fromTransposer.m_FollowOffset, toTransposer.m_FollowOffset, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset the blend to avoid affecting other cameras
        CinemachineCore.Instance.GetActiveBrain(0).m_DefaultBlend = new CinemachineBlendDefinition();
    }
}
