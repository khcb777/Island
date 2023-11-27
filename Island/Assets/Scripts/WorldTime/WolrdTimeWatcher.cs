using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace WorldTime
{
    public class WolrdTimeWatcher : MonoBehaviour
    {
        //–асписание дл€ времени

        [SerializeField]
        private WorldTime _worldTime;

        [SerializeField]
        private List<Schedule> _shedule;

        private void Start()
        {
            _worldTime.WorldTimeChanged += CheckSchedule;
        }

        private void OnDestroy()
        {
            _worldTime.WorldTimeChanged -= CheckSchedule;
        }

        //ѕровер€ем если по времени совпадат с расписанием то запускаем событие
        private void CheckSchedule(object sender, TimeSpan newTime)
        {
            var shedule = 
                _shedule.FirstOrDefault(s =>
                    s.Hour == newTime.Hours &&
                    s.Mitute == newTime.Minutes);

            shedule._action?.Invoke();
        }

        [Serializable]
        private class Schedule
        {
            public int Hour;
            public int Mitute;

            public UnityEvent _action;
        }
    }
}