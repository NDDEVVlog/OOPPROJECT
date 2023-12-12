using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DynamicAudio;
public class TestSoundScript : MonoBehaviour
{
    public DynamicSound sound;
    public GameObject testOb;

    [Button()]
    void RunSound()
    {
        sound.PlaySound(testOb.GetComponent<ObjectInfo>());
    }
}
