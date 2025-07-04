using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRendererController : MonoBehaviour
{
    private StateManager _stateManager;
    private Animator _animator;

    private float _typeOfAction;
    private float _gunType;
    private float _shootingType;
    private float _landing;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();

        SetTypeOfAction(1f);
    }

    public void SetTypeOfAction(float type)
    {
        _animator.SetFloat("TypeOfAction(1-Moving)", type);
    }

    public void Move(Vector2 direction)
    {
        if (direction.y != 0)
        {
            _animator.SetFloat("FlyForvardBack", direction.normalized.y);
            _animator.SetFloat("FlyLeftRight", 0f);
        }
        else if (direction.x != 0)
        {
            _animator.SetFloat("FlyLeftRight", direction.normalized.x);
            _animator.SetFloat("FlyForvardBack", 0f);
        }
        else
        {
            _animator.SetFloat("FlyLeftRight", 0f);
            _animator.SetFloat("FlyForvardBack", 0f);
        }
    }

    public void Rotate(float angle)
    {
        _animator.SetFloat("Angle", angle);
    }

    public void Shoot()
    {
        if (_typeOfAction == 1f)
        {
            _animator.SetFloat("TypeOfAction(1-Moving)", 2f);

            if (_stateManager.GunState == GunStates.Flamethrover_vertical)
            {
                _animator.SetFloat("GunType(1-Flamethrover)", 1f);
                _animator.SetFloat("ShootingType(1-Horizontal)", 0f);
            }
            else if (_stateManager.GunState == GunStates.Flamethrover_horizontal)
            {
                _animator.SetFloat("GunType(1-Flamethrover)", 1f);
                _animator.SetFloat("ShootingType(1-Horizontal)", 1f);
            }
            else if (_stateManager.GunState == GunStates.Gun_horizontal)
            {
                _animator.SetFloat("GunType(1-Flamethrover)", 0f);
                _animator.SetFloat("ShootingType(1-Horizontal)", 1f);
            }
            else if (_stateManager.GunState == GunStates.Gun_vertical)
            {
                _animator.SetFloat("GunType(1-Flamethrover)", 0f);
                _animator.SetFloat("ShootingType(1-Horizontal)", 0f);
            }

            Invoke(nameof(StopShooting), 3f);
        }
    }

    public void Hit()
    {

    }

    public void Landing(bool takeoff)
    {
        if (takeoff)
        {
            if (_landing == 0f)
            {
                _animator.SetFloat("Landing(0-StayLanded)", 1f);
                Invoke("TakeoffOrLand", 0.8f);
            }
        }
        else
        {
            if (_typeOfAction == 1f)
            {
                _animator.SetFloat("TypeOfAction(1-Moving)", 3f);
                _animator.SetFloat("Landing(0-StayLanded)", -1f);
                _stateManager.MovingState = MovingStates.NotMove;
                Invoke("TakeoffOrLand", 0.8f);
            }
        }
    }

    private void TakeoffOrLand()
    {
        if (_landing == 1f)
        {
            SetTypeOfAction(1f);
            _stateManager.MovingState = MovingStates.Move;
        }
        else if (_landing == -1f)
        {
            _animator.SetFloat("Landing(0-StayLanded)", 0f);
        }
    }

    private void Update()
    {
        _gunType = _animator.GetFloat("GunType(1-Flamethrover)");
        _shootingType = _animator.GetFloat("ShootingType(1-Horizontal)");
        _typeOfAction = _animator.GetFloat("TypeOfAction(1-Moving)");
        _landing = _animator.GetFloat("Landing(0-StayLanded)");

        //Debug.Log($"Gun Type: {_gunType}, Shooting Type: {_shootingType}, Type of Action: {_typeOfAction}, Landing: {_landing}");
    }

    private void StopShooting()
    {
        SetTypeOfAction(1);
    }
}
