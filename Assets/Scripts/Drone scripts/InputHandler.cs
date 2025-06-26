using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private DroneMove _droneMove;

    private void Awake()
    {
        _droneMove = GetComponent<DroneMove>();
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
}
