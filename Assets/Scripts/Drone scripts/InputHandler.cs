using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private DroneMove _droneMove;
    private FireRendererController _fireRendererController;
    private DroneRendererController _droneRendererController;
    private StateManager _stateManager;

    private void Awake()
    {
        _droneMove = GetComponent<DroneMove>();
        _fireRendererController = GetComponentInChildren<FireRendererController>();
        _droneRendererController = GetComponentInChildren<DroneRendererController>();
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
        if (_stateManager.MovingState == MovingStates.Move)
        {
            _fireRendererController.Shoot();
            _droneRendererController.Shoot();
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _droneMove.Run();
        }
        else
        {
            _droneMove.NotRun();
        }
    }
}
