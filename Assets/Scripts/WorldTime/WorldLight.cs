using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WorldTime
{   /*
     This will adjust light 2D
     
     
     */
    [RequireComponent(typeof(Light2D))]
    public class WorldLight : MonoBehaviour
    {   

        private Light2D _light;

        [SerializeField]
        private WorldTime worldTime;

        [SerializeField]
        private Gradient gradient;
        private void Awake()
        {
            _light = GetComponent<Light2D>();
            worldTime.WorldTimeChanged += OnWorldTimeChanged;

        }
        private void OnDestroy()
        {
            worldTime.WorldTimeChanged -= OnWorldTimeChanged;
        }
        void OnWorldTimeChanged(object sender,TimeSpan newTime)
        {
            _light.color = gradient.Evaluate(PercentoOfDay(newTime));
        }
        float PercentoOfDay(TimeSpan time)
        {
            return (float)time.TotalMinutes % WorldTimeConstant.MinutesInDay / WorldTimeConstant.MinutesInDay;
        }
    }
}