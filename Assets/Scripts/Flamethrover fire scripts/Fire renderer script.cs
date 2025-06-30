using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRendererScript : MonoBehaviour
{
    private StateManager _stateManager;
    private Animator _animator;

    private bool _animationFinished = true;

    private void Awake()
    {
        _stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
        _animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        if (_animationFinished)
        {
            _animationFinished = false;

            if (_stateManager.GunState == GunStates.Flamethrover_horizontal)
            {
                _animator.Play("Horizontal");
            }
            else if (_stateManager.GunState == GunStates.Flamethrover_vertical)
            {
                _animator.Play("Vertical");
            }

            StartCoroutine(FinishAnimation());
        }
    }

    private IEnumerator FinishAnimation()
    {
        yield return new WaitForSeconds(3f);

        _animationFinished = true;

        _animator.Play("DontFire");

        _stateManager.FlyingState = FlyingStates.Flying;
    }
}
