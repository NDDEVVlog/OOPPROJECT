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

    public virtual void AssignVariable (GameObject parent)
    {

    }
    public virtual void Activate(GameObject parent)
    { 

    }
    public virtual void Activate(GameObject parent, float Time)
    {

    }
}
