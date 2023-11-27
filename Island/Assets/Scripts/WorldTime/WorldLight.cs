using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WorldTime
{
    [RequireComponent(typeof(Light2D))]//������� ��������� �����
    public class WorldLight : MonoBehaviour
    {
        private Light2D _ligth;

        [SerializeField]
        private WorldTime _worldTime;

        [SerializeField]
        private Gradient _gradient;//�������� ����� ��� ������� ������� �����

        private void Awake()
        {
            _ligth = GetComponent<Light2D>();

            _worldTime.WorldTimeChanged += OnWorldTimeChanged;//������������� �� ������� ��������� �������
        }

        private void OnDestroy()
        {
            _worldTime.WorldTimeChanged -= OnWorldTimeChanged;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            _ligth.color = _gradient.Evaluate(PercentOfDay(newTime));
        }

        private float PercentOfDay(TimeSpan timeSpan)//��������� ����� � �������� (��� ���������)
        { 
            return (float) timeSpan.TotalMinutes % WorldTimeConstants.MinutesInDay / WorldTimeConstants.MinutesInDay;
        }
    }
}
