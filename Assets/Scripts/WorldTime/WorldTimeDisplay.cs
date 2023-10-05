using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
namespace WorldTime
{
    public class WorldTimeDisplay : MonoBehaviour
    {
        [SerializeField]
        private WorldTime worldTime;
        private TMP_Text text;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
            worldTime.WorldTimeChanged += OnWorldTimeChanged;
        }
        private void OnDestroy()
        {
            worldTime.WorldTimeChanged -= OnWorldTimeChanged;
        }
        private void OnWorldTimeChanged(object sender, TimeSpan newtime)
        {
            text.SetText(newtime.ToString(@"hh\:mm"));
        }
    }
}
