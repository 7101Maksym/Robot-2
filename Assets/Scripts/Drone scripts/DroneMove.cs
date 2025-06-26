using UnityEngine;

public class DroneMove : MonoBehaviour
{
    private StateManager _stateManager;
    private RenderController[] _renderController;
    private Rigidbody2D _rb;

    private Vector2 forvard, back, left, right;
    private Vector2 _direction;
    private int WS, AD;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _stateManager = GetComponent<StateManager>();
        _renderController = GetComponentsInChildren<RenderController>();
    }

    private void Update()
    {
        back = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        back = back.normalized;
        forvard = -back.normalized;
        left = Vector2.Perpendicular(forvard).normalized;
        right = -left;
    }

    private void FixedUpdate()
    {
        if (_stateManager.FlyingState == FlyingStates.Flying)
        {
            SetDirectionInProcess();
            _rb.velocity = _direction * 5f;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }

    private void SetDirectForAllRenderers(int direction)
    {
        foreach (var render in _renderController)
        {
            render.SetFlyDirection(direction);
        }
    }

    private void SetTakeoffOrLandForAllRenderers(FlyingStates state)
    {
        foreach (var render in _renderController)
        {
            render.TakeoffOrLand(state);
        }
    }

    private void SetDirectionInProcess()
    {
        if (WS == 0 && AD == 0)
        {
            _direction = Vector2.zero;
            SetDirectForAllRenderers(0);
            return;
        }
        else if (WS == 0 && AD == 1)
        {
            _direction = right;
            SetDirectForAllRenderers(2);
            return;
        }
        else if (WS == 0 && AD == -1)
        {
            _direction = left;
            SetDirectForAllRenderers(4);
            return;
        }
        else if (WS == 1 && AD == 0)
        {
            _direction = forvard;
            SetDirectForAllRenderers(1);
            return;
        }
        else if (WS == -1 && AD == 0)
        {
            _direction = back;
            SetDirectForAllRenderers(3);
            return;
        }
    }

    public void SetDirection(int WS, int AD)
    {
        this.WS = WS;
        this.AD = AD;
    }

    public void TakeoffOrLand(int LandOrTakeoff)
    {
        if (LandOrTakeoff != 0)
        {
            if (LandOrTakeoff == 1 && _stateManager.FlyingState == FlyingStates.Landed)
            {
                SetTakeoffOrLandForAllRenderers(FlyingStates.Flying);
            }
            else if (LandOrTakeoff == -1 && _stateManager.FlyingState == FlyingStates.Flying)
            {
                SetTakeoffOrLandForAllRenderers(FlyingStates.Landed);
            }
        }
    }
}
