using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class BaseSingleAbilitySkill:ScriptableObject
{
    public KeyCode keyCode;
    public AnimationClip clip;
    public new string name;
    public float coolDownTime;
    public float activeTime;

    public float tempActiveTime;
    public float tempCoolDownTime;
    enum AbilityState
    {
        ready,
        active,
        cooldown

    }

    AbilityState state = AbilityState.ready;

    public virtual void AssignVariable (GameObject parent)
    {
    }
    public virtual void Activate(GameObject parent)
    { 

    }
    public virtual void Activate(GameObject parent, float Time)
    {

    }
    public virtual bool ReturnInputValue(float Time)
    {
        return true;
    }
    public virtual void Deactivate()
    {

    }
    public void Check(float TimeDelta, float TimeFixedDelta, GameObject owner)
    {
        
        switch (state)
        {
            case AbilityState.ready:
                if (ReturnInputValue(TimeDelta))
                {
                    
                    //tempActiveTime = activeTime;

                    Activate(owner);
                    state = AbilityState.active;
                    activeTime = tempActiveTime;
                }
                break;
            case AbilityState.active:
                if (activeTime > 0)
                { 

                    Activate(owner, TimeFixedDelta);

                    activeTime -= TimeDelta;
                }
                else
                {
                    //tempCoolDownTime = coolDownTime;
                    state = AbilityState.cooldown;
                    coolDownTime = tempCoolDownTime;
                }
                break;
            case AbilityState.cooldown:
                if (coolDownTime > 0)
                {
                    coolDownTime -= TimeDelta;
                }
                else
                {
                    Deactivate();
                    state = AbilityState.ready;

                }
                break;
        }

    }
}
