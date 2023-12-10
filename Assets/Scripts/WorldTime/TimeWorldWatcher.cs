using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;

namespace WorldTime
{
    public class TimeWorldWatcher : MonoBehaviour
    {
        [SerializeField]
        private WorldTime _worldTime;

        public List<Schedule> schedules;
        private void Start()
        {
            _worldTime.WorldTimeChanged += CheckSchedule;
        }
        private void OnDestroy()
        {
            _worldTime.WorldTimeChanged -= CheckSchedule;

        }
        void CheckSchedule(object sender, TimeSpan newTime)
        {
            var schedulde = schedules.FirstOrDefault(s => s.Hour == newTime.Hours && s.Minute == newTime.Minutes);
            schedulde?.unityEvent ?. Invoke();
        }

        [Serializable]
        public class Schedule
        {
            public int Hour;
            public int Minute;
            public UnityEvent unityEvent;
        }

    }
}
