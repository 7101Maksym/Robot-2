using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private GunStates DefaultGunState;
    [SerializeField] private MovingStates DefaultMovingState;

    public GunStates GunState { get; set; }

    public MovingStates MovingState { get; set; }

    private void Awake()
    {
        GunState = DefaultGunState;
        MovingState = DefaultMovingState;
    }
}
