using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderersHandler : MonoBehaviour
{
    private RenderController[] _renderControllers;

    private void Awake()
    {
        _renderControllers = GetComponentsInChildren<RenderController>();
    }

    public void SetDirectForAllRenderers(int direction)
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
}
