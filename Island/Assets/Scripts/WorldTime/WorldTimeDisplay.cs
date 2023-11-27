using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace WorldTime
{
    [RequireComponent(typeof(TMP_Text))]//Требует добавить компонент текстового поля (для отображения часов)
    public class WorldTimeDisplay : MonoBehaviour
    {
        [SerializeField]
        private WorldTime _worldTime;

        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _worldTime.WorldTimeChanged += OnWorldTimeChanged;//Подписываемся на событие изменения времени
        }

        private void OnDestroy()
        {
            _worldTime.WorldTimeChanged -= OnWorldTimeChanged;//Отписываемся от события изменения времени.
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            _text.SetText(newTime.ToString(@"hh\:mm"));
        }
    }
}
