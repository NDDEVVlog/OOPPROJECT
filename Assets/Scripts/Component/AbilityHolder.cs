using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public BaseSingleAbilitySkill abilitySkill;
    float coolDowTime;
    float activeTime;
    
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
        keyCode = abilitySkill.keyCode;
        abilitySkill.AssignVariable(this.gameObject);
    }
    private void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(keyCode))
                {
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
                    state = AbilityState.ready;

                }
                break;
        }
       
    }
}
