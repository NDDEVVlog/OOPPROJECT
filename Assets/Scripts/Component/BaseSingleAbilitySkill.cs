using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BaseSingleAbilitySkill
{
    public KeyCode keyCode;
    public AnimationClip clip;
    public SkillFunction function;
}
public interface SkillFunction
{
    public void Evalute();
}