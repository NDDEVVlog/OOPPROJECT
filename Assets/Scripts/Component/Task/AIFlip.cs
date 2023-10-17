using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFlip : MonoBehaviour
{
    bool shouldFlip = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetFloat("Direction", 1);


        if (GetComponent<Movement>()._direction.x < 0 && shouldFlip)
        {
            FlipGun();

            shouldFlip = false;
        }
        else if (GetComponent<Movement>()._direction.x > 0 && !shouldFlip)
        {
            FlipGun();

            shouldFlip = true;
        }

    }
    void FlipGun( )
    {
        //var flipNum = angle >= 180 ? 1 : -1;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
