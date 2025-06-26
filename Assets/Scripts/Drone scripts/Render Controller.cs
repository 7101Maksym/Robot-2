using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderController : MonoBehaviour
{
    private StateManager _stateManager;
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _stateManager = GetComponentInParent<StateManager>();
    }

    public void SetFlyDirection(int direction)
    {
        switch (direction)
        {
            case 0:
                _animator.Play("Idle");
                break;
            case 1:
                _animator.Play("Fly forvard");
                break;
            case 2:
                _animator.Play("Fly right");
                break;
            case 3:
                _animator.Play("Fly back");
                break;
            case 4:
                _animator.Play("Fly left");
                break;
        }
    }

    public void TakeoffOrLand(FlyingStates toFlyingState)
    {
        if (toFlyingState == FlyingStates.Landed)
        {
            _stateManager.FlyingState = FlyingStates.Landed;
            _animator.Play("Land");
            Invoke(nameof(StayLanded), 0.8f);
        }
        else if (toFlyingState == FlyingStates.Flying)
        {
            _animator.SetBool("isLanded", false);
            _animator.Play("Takeoff");
            Invoke(nameof(Takeoff), 0.8f);
        }
    }

    private void StayLanded()
    {
        _animator.SetBool("isLanded", true);
    }

    private void Takeoff()
    {
        _stateManager.FlyingState = FlyingStates.Flying;
    }
}
