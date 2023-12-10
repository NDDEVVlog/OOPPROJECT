using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicAudio;
public class DynamicSound : MonoBehaviour
{
    public SoundHolder soundHolder;
    public void PlaySound(ObjectInfo objectInfo)
    {
        //Get Enum Value Number
        int value = ReturnObjectNumber(objectInfo);

        Sound[] sounds = ReturnSounds(value);

        objectInfo.source.clip = sounds[Random.Range(0,sounds.Length)].audioClip;
        objectInfo.source.PlayOneShot(objectInfo.source.clip);
    }
    public void PlaySound(int layer,GameObject ob)
    {
        string mask = LayerMask.LayerToName(layer);
        MaterialType materialType;
        if(System.Enum.TryParse(mask,out materialType))
        {
            materialType = (MaterialType)System.Enum.Parse(typeof(MaterialType), mask);

            int value = (int)System.Enum.Parse(typeof(MaterialType), materialType.ToString());

            Sound[] sounds = ReturnSounds(value);
            AudioSource source = ob.GetComponent<AudioSource>();
            source.clip = sounds[Random.Range(0, sounds.Length)].audioClip;
            source.PlayOneShot(source.clip);
        }
        
    }
    Sound[] ReturnSounds(int value)
    {
        return soundHolder.objectAudios[value].objectSounds;
    }
    int ReturnObjectNumber(ObjectInfo objectInfo)
    {
        return (int)System.Enum.Parse(typeof(MaterialType), objectInfo.materialType.ToString());
    }    
}
