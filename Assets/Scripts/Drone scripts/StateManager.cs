using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GunStates GunState = GunStates.Gun_horizontal;

    public FlyingStates FlyingState = FlyingStates.Flying;

    public ShootingStates ShootingState = ShootingStates.Shooting;
}
