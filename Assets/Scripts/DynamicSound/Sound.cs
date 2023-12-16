using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
namespace DynamicAudio
{
    [System.Serializable]

    public class Sound
    {
        public AudioClip audioClip;
        [Range(0, 256)]
        public float piority;
        [Range(0, 1)]
        public float volume;
    }
    [System.Serializable]
    public struct ObjectAudio // idk what should i name this lol
    {   
        [ReadOnly]
        public MaterialType materialType;
        public Sound[] objectSounds;
        public ParticleSystem[] particleSystems;
    }
    public enum MaterialType
    {
        Gravel,
        Water,
        Stone,
        Wood,
        Concrete,
        Dirt,
        Grass,
        Glass,
        Metal,
        None

    }
    [System.Serializable]
    public class SoundHolder
    {
        public ObjectAudio[] objectAudios = new ObjectAudio[System.Enum.GetValues(typeof(MaterialType)).Length];
        public SoundHolder()
        {
            for(int i  = 0; i < System.Enum.GetValues(typeof(MaterialType)).Length;i++)
            {
                objectAudios[i].materialType = (MaterialType)i;
            }
        }
    }
    
}
