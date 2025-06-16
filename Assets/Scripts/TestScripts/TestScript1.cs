using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript1 : MonoBehaviour
{
    //вызывается при загрузке объекта на сцену
    private void Awake()
    {
        Debug.Log("Awake");
    }

    //вызывается при активации объекта
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    //вызывается при отрисовке первого кадра
    private void Start()
    {
        Debug.Log("Start");
    }

    //вызывается каждый кадр (FPS)
    private void Update()
    {
        Debug.Log("Update");
    }

    //вызывается с фиксированной частотой
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    //вызывается сразу после Update
    private void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    //вызывается при отключении объекта
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    //вызывается при уничтожении объекта
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
