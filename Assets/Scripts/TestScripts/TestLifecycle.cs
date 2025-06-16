using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript1 : MonoBehaviour
{
    //���������� ��� �������� ������� �� �����, ������������ ��� ������������� �����������
    private void Awake()
    {
        Debug.Log("Awake");
    }

    //���������� ��� ��������� �������
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    //���������� ��� ��������� ������� �����
    private void Start()
    {
        Debug.Log("Start");
    }

    //���������� ������ ���� (FPS), ������������ ��� ��������� ��������
    private void Update()
    {
        Debug.Log("Update");
    }

    //���������� � ������������� ��������, ������������ ��� ������
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    //���������� ����� ����� Update, ������������ ��� ��������� UI � �����������
    private void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    //���������� ��� ���������� �������
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    //���������� ��� ����������� �������
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
