using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WorldTime
{
    public class WorldTime : MonoBehaviour
    {
        public event EventHandler<TimeSpan> WorldTimeChanged;//Событие изменения времени

        [SerializeField]
        private float _dayLength; //Длинна дня в секундах

        private TimeSpan _currentTime;

        private float _minuteLength => _dayLength / WorldTimeConstants.MinutesInDay; // Вычисляем длнну минуты 

        private void Start()
        {
            StartCoroutine(AddMinute());
        }

        private IEnumerator AddMinute()//Добавляет минуты к времени через время _minuteLength
        {
            _currentTime += TimeSpan.FromMinutes(1);

            WorldTimeChanged?.Invoke(this, _currentTime); //Вызываем событие после изменения времени и передаем текущее время

            yield return new WaitForSeconds(_minuteLength);

            StartCoroutine(AddMinute());    
        }

    }
}