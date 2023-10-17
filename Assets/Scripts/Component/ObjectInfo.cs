using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class ObjectInfo : MonoBehaviour
{
    public ObjectEffect[] objectEffect;


    
}
public enum ObjectMaterial
{
    Wood,
    Concrete,
    Gravel,
    Water,
    Ice,
    Dirt,
    Grass
}
[System.Serializable]
public struct ObjectEffect
{
    public ObjectMaterial obMaterial;
    public ParticleSystem particle;
    public AudioClip[] audioClip;

}


