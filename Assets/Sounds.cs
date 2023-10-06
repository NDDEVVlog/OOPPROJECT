using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]  // Start is called before the first frame update
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume;
        [Range(.1f, 3f)]
        public float pitch;


    [HideInInspector]
        public AudioSource source;
    }
