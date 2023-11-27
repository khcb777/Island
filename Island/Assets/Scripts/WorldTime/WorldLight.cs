using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WorldTime
{
    [RequireComponent(typeof(Light2D))]//Требуем компонент света
    public class WorldLight : MonoBehaviour
    {
        private Light2D _ligth;

        [SerializeField]
        private WorldTime _worldTime;

        [SerializeField]
        private Gradient _gradient;//Градиент света для разного времени суток

        private void Awake()
        {
            _ligth = GetComponent<Light2D>();

            _worldTime.WorldTimeChanged += OnWorldTimeChanged;//Подписываемся на событие изменения времени
        }

        private void OnDestroy()
        {
            _worldTime.WorldTimeChanged -= OnWorldTimeChanged;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            _ligth.color = _gradient.Evaluate(PercentOfDay(newTime));
        }

        private float PercentOfDay(TimeSpan timeSpan)//Переводим время в проценты (для градиента)
        { 
            return (float) timeSpan.TotalMinutes % WorldTimeConstants.MinutesInDay / WorldTimeConstants.MinutesInDay;
        }
    }
}
