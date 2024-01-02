using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamicAudio
{
    [RequireComponent(typeof(AudioSource))]
    public class ObjectInfo : MonoBehaviour
    {
        public Sound[] ownedSound;
        public ParticleSystem particle;
        public AudioSource source;
        public MaterialType materialType;
        public void Awake()
        {
            source = GetComponent<AudioSource>();
            source.spatialBlend = 1f;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
    
}