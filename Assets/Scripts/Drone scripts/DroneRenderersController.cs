using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRenderersController : MonoBehaviour
{
    private DroneRendererScript[] _renderControllers;

    private bool _canShoot = true;

    private void Awake()
    {
        _renderControllers = GetComponentsInChildren<DroneRendererScript>();
    }

    public void SetDirectForAllRenderers(int direction = 0)
    {
        foreach (var render in _renderControllers)
        {
            render.SetFlyDirection(direction);
        }
    }

    public void SetTakeoffOrLandForAllRenderers(FlyingStates state)
    {
        foreach (var render in _renderControllers)
        {
            render.TakeoffOrLand(state);
        }
    }

    public void SetShootForAllRenderers()
    {
        if (_canShoot)
        {
            _canShoot = false;

            foreach (var render in _renderControllers)
            {
                render.Shoot();
            }

            Invoke(nameof(SetIdleForAllRenderers), 2f);
            Invoke(nameof(CanShoot), 3f);
        }
    }

    private void SetIdleForAllRenderers()
    {
        SetDirectForAllRenderers(0);
    }

    private void CanShoot()
    {
        _canShoot = true;
    }
}
