using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnewayPlatform : MonoBehaviour
{
    [SerializeField]
    bool isCharacter = false;

    

    private void Update()
    {
        if (isCharacter)
        {
            if(Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (GetComponent<PlatformEffector2D>())
                {
                    GetComponent<PlatformEffector2D>().rotationalOffset = 180f;
                    StartCoroutine(OneWayTime());
                }
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            isCharacter = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the collider not the parent
        if (collision.gameObject.CompareTag("Player"))
        {
            isCharacter = true;
        }
    }
    IEnumerator OneWayTime()
    {
        yield return new WaitForSeconds(0.5f);

        GetComponent<PlatformEffector2D>().rotationalOffset = 0f;


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            isCharacter = false;
        }
    }

}