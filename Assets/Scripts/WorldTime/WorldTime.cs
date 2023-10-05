using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace WorldTime
{
    /*
     This script is a copy version of this Video : https://www.youtube.com/watch?v=0nq1ZFxuEJY
     We gonna made a cycle Day and Night in the game
     
     */

    public class WorldTime : MonoBehaviour
    {
        public event EventHandler<TimeSpan> WorldTimeChanged; // Yep, i must learn this


        [SerializeField]
        private float _dayLength; // in second

        private TimeSpan currentTime;

        private float minuteLength => _dayLength / WorldTimeConstant.MinutesInDay; //=> is return

        private void Start()
        {
            StartCoroutine(AddMinute());
        }
        IEnumerator AddMinute()
        {
            currentTime += TimeSpan.FromMinutes(1);
            yield return new WaitForSeconds(minuteLength);
            WorldTimeChanged?.Invoke(this,currentTime);
            StartCoroutine(AddMinute());
        }
    }

    
}