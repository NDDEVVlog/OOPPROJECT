    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicAudio;
public class DynamicSound
{
    
    public static void PlaySound(ObjectInfo objectInfo, SoundHolder soundHolder)
    {
        //Get Enum Value Number
        int value = ReturnObjectNumber(objectInfo);
        MaterialType type = (MaterialType)value;
        if(type == MaterialType.None)
        {
            objectInfo.source.clip = objectInfo.ownedSound[Random.Range(0, objectInfo.ownedSound.Length)].audioClip;
            objectInfo.source.PlayOneShot(objectInfo.source.clip);
            return;

        }
        //Get Sound 
        Sound[] sounds = ReturnSounds(soundHolder,value);

        objectInfo.source.clip = sounds[Random.Range(0,sounds.Length)].audioClip;
        objectInfo.source.PlayOneShot(objectInfo.source.clip);
    }
    public static void PlaySound(ObjectInfo objectInfo)
    {
        objectInfo.source.clip = objectInfo.ownedSound[Random.Range(0, objectInfo.ownedSound.Length)].audioClip;
        objectInfo.source.PlayOneShot(objectInfo.source.clip);
    }
    
    public static void PlaySound(int layer,GameObject ob, SoundHolder soundHolder)
    {
        string mask = LayerMask.LayerToName(layer);
        MaterialType materialType;
        if(System.Enum.TryParse(mask,out materialType))
        {
            materialType = (MaterialType)System.Enum.Parse(typeof(MaterialType), mask);

            int value = (int)System.Enum.Parse(typeof(MaterialType), materialType.ToString());
           
            Sound[] sounds = ReturnSounds(soundHolder,value);
            AudioSource source = ob.GetComponent<AudioSource>();
            source.clip = sounds[Random.Range(0, sounds.Length)].audioClip;
            source.PlayOneShot(source.clip);
        }
        
    }
    public static void PlaySound(MaterialType materialType, SoundHolder soundHolder,GameObject ob)
    {

        int i = (int)materialType;
        Sound[] sounds = ReturnSounds(soundHolder, i);
        AudioSource source = ob.GetComponent<AudioSource>();
        source.clip = sounds[Random.Range(0, sounds.Length)].audioClip;
        source.PlayOneShot(source.clip);

    }
    static Sound[] ReturnSounds(SoundHolder holder, int value)
    {
        return holder.objectAudios[value].objectSounds;
    }
    static int ReturnObjectNumber(ObjectInfo objectInfo)
    {
        return (int)System.Enum.Parse(typeof(MaterialType), objectInfo.materialType.ToString()); // return the number of element in Enum
    }    
}
