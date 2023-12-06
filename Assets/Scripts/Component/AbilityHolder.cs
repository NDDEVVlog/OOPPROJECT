using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public BaseSingleAbilitySkill[] abilitySkill;
    
    
    enum AbilityState
    {
        ready,
        active,
        cooldown

    }

    AbilityState state = AbilityState.ready;

    public KeyCode keyCode;
    private void Awake()
    {
        foreach (BaseSingleAbilitySkill a in abilitySkill)
        {
            keyCode = a.keyCode;
            a.AssignVariable(this.gameObject);
        }
    }
    private void Update()
    {
        foreach (BaseSingleAbilitySkill a in abilitySkill)
            a.Check(Time.deltaTime,Time.fixedDeltaTime,this.gameObject);


        /*switch (state)
        {
            case AbilityState.ready:
                if (abilitySkill.ReturnInputValue(Time.deltaTime))
                {
                    Debug.Log("hi");
                    abilitySkill.Activate(this.gameObject);
                    state = AbilityState.active;
                    activeTime = abilitySkill.activeTime;
                }
                break;
            case AbilityState.active:
                if(activeTime > 0)
                {
                    abilitySkill.Activate(this.gameObject,Time.fixedDeltaTime);

                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.cooldown;
                    coolDowTime = abilitySkill.coolDownTime;
                }
                break;
            case AbilityState.cooldown:
                if (coolDowTime > 0)
                {
                    coolDowTime -= Time.deltaTime;
                }
                else
                {
                    abilitySkill.Deactivate();
                    state = AbilityState.ready;

                }
                break;
        }*/
       
    }
}
