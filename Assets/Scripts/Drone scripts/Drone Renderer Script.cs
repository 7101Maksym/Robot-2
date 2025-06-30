using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRendererScript : MonoBehaviour
{
    private StateManager _stateManager;
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
    }

    public void Shoot()
    {
        switch (_stateManager.GunState)
        {
            case GunStates.Flamethrover_horizontal:
                _animator.Play("Flamethrover horizontal");
                break;
            case GunStates.Flamethrover_vertical:
                _animator.Play("Flamethrover vertical");
                break;
            case GunStates.Gun_horizontal:
                _animator.Play("Gun horizontal");
                break;
            case GunStates.Gun_vertical:
                _animator.Play("Gun vertical");
                break;
        }
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
