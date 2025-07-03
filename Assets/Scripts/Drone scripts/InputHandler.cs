using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private DroneMove _droneMove;
    private FireRenderersController _fireRenderersController;
    private DroneRendererController _droneRendererController;
    private StateManager _stateManager;

    private void Awake()
    {
        _droneMove = GetComponent<DroneMove>();
        _fireRenderersController = GetComponentInChildren<FireRenderersController>();
        _droneRendererController = GetComponentInChildren<DroneRendererController>();
        _stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var movement = context.ReadValue<Vector2>();
        _droneMove.SetDirection((int)movement.y, (int)movement.x);
        _droneRendererController.Move(movement);
    }

    public void OnTakeoffOrLand(InputAction.CallbackContext context)
    {
        var takeoffOrLand = context.ReadValue<float>();

        if (takeoffOrLand < 0f)
        {
            if (_stateManager.MovingState == MovingStates.Move)
            {
                _droneRendererController.Landing(false);
            }
        }
        else if (takeoffOrLand > 0f)
        {
            _droneRendererController.Landing(true);
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {

    }
}
