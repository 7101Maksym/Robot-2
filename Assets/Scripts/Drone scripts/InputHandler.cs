using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private DroneMove _droneMove;
    private FireRenderersController _fireRenderersController;
    private DroneRenderersController _droneRenderersController;
    private StateManager _stateManager;

    private void Awake()
    {
        _droneMove = GetComponent<DroneMove>();
        _fireRenderersController = GetComponentInChildren<FireRenderersController>();
        _droneRenderersController = GetComponentInChildren<DroneRenderersController>();
        _stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var movement = context.ReadValue<Vector2>();
        _droneMove.SetDirection((int)movement.y, (int)movement.x);
    }

    public void OnTakeoffOrLand(InputAction.CallbackContext context)
    {
        var takeoffOrLand = context.ReadValue<float>();
        _droneMove.TakeoffOrLand((int)takeoffOrLand);
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (_stateManager.FlyingState == FlyingStates.Flying)
        {
            _fireRenderersController.Shoot();
            _droneRenderersController.SetShootForAllRenderers();
        }
    }
}
