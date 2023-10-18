using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMinigame : MonoBehaviour
{
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [SerializeField] GameObject fish;
        
    float fishPosition;
    float fishDestination;

    float fishTimer;
    [SerializeField] float timerMultiplicator = 3f;

    float fishSpeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] GameObject hook;

    float hookPosition;

    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower = 0.5f;
    float hookProgress;
    public float hookPullVelocity;

    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookProgressDergradationPower = 0.1f;

    [SerializeField] SpriteRenderer hookSpriteRender;

    [SerializeField] Transform progressBarContainer;

    bool pause = false;

    [SerializeField] float failTimer = 10f; 

    private void Start()
    {
        //Resize();
    }
    private void Update()
    {
        if (pause)
        {
            return;
        }
        Fish();
        Hook();
        ProgressCheck();
    }

    private void Resize()
    {
        Bounds b = hookSpriteRender.bounds;
        float ySize = b.size.y;
        Vector3 ls = hook.transform.localScale;
        float distance = Vector3.Distance(topPivot.position, bottomPivot.position);
        ls.y = (distance / ySize * hookSize);
        hook.transform.localScale = ls;
    }
    private void ProgressCheck()
    {
        Vector3 ls = progressBarContainer.localScale;
        ls.y = hookProgress;
        progressBarContainer.localScale = ls;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if (min < fishPosition && fishPosition < max)
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else{
            hookProgress -= hookProgressDergradationPower * Time.deltaTime;
        }

        failTimer -= Time.deltaTime;
        if(failTimer < 0f)
        {
            Lose();
        }

        if (hookProgress >= 1f)
        {
            Win();
        }
        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }

    private void Lose()
    {
        pause = true;
        Debug.Log("YOU LOSE! FISH SWIMS AWAY FROM YOU!");
    }

    private void Win()
    {
        pause = true;
        Debug.Log("YOU WIN! YOU CAUGHT THE FISH!");
    }
    void Hook()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("GetMouse");
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }
        hookPullVelocity -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if ((hookPosition - hookSize / 2 <= 0f) && hookPullVelocity < 0f)
        {
            hookPullVelocity = 0f;
        }
        if (hookPosition + hookSize /2 >= 1f && hookPullVelocity > 0f)
        {
            hookPullVelocity = 0f;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize/2);
        hook.transform.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);
    }

    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            fishTimer = UnityEngine.Random.value * timerMultiplicator;
            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fish.transform.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPosition);
    }


}
