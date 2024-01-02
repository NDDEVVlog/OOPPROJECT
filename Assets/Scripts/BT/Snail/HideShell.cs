using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class HideShell : BehaviorTree.Node
{
    public SnailBT snail;
    public SnailHealth snailHealth;
    private float _WaitTime = 0f;
    private float _WaitCounter = 0f;
    public HideShell(SnailBT snail,SnailHealth snailHealth, float _WaitTime)
    {
        this.snail = snail;
        this.snailHealth = snailHealth;
        this._WaitTime = _WaitTime;

    }

    public override NodeState Evalute()
    {
        
        snailHealth.Hide = true;
        if (snail.onTakeDamage)
        {
            Debug.Log(_WaitCounter);
            _WaitCounter += Time.deltaTime;
            if (_WaitCounter >= _WaitTime)
            {   
                snail.gameObject.GetComponent<Animator>().SetFloat("ReverseValue", -1);


                snail.ai.xValue = Mathf.Lerp(snail.ai.xValue,snail.gameObject.transform.localScale.x,Time.deltaTime);
                snail.gameObject.GetComponent<Animator>().SetBool("Hide", false);
                snail.gameObject.GetComponent<Animator>().Play("Snail hide");


                snailHealth.Hide = false;
                snail.onTakeDamage = false;
                _WaitCounter = 0;


                state = NodeState.SUCCESS;
                return state;
            }
            else
            {
                snail.gameObject.GetComponent<Animator>().SetFloat("ReverseValue", 1);

                snail.gameObject.GetComponent<Animator>().SetBool("Hide", true);

                snail.ai.xValue = 0;

            }
        }
        


        return NodeState.RUNNING;
    }
}
