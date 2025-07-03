using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRendererScript : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        //_animator.Play()
    }
}
