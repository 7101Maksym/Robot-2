using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightSetter : MonoBehaviour
{
    [SerializeField] private float _settingSpeed = 1f;

    private Light2D _light;

    private bool _day = true;

    private void Awake()
    {
        _light = GetComponent<Light2D>();
    }

    private void Update()
    {
        if (_light.intensity >= 1)
        {
            _day = false;
        }
        else if (_light.intensity <= 0.03f)
        {
            _day = true;
        }

        if (_day)
        {
            _light.intensity += Time.deltaTime * _settingSpeed;
        }
        else
        {
            _light.intensity -= Time.deltaTime * _settingSpeed;
        }
    }
}
