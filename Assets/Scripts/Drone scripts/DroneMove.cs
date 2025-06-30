using UnityEngine;

public class DroneMove : MonoBehaviour
{
    private StateManager _stateManager;
    private Rigidbody2D _rb;
    private DroneRenderersController _renderersHandler;

    private Vector2 forvard, back, left, right;
    private Vector2 _direction;
    private int WS, AD;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
        _renderersHandler = GetComponentInChildren<DroneRenderersController>();
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

    private void SetDirectionInProcess()
    {
        if (WS == 0 && AD == 0)
        {
            _direction = Vector2.zero;
            _renderersHandler.SetDirectForAllRenderers(0);
            return;
        }
        else if (WS == 0 && AD == 1)
        {
            _direction = right;
            _renderersHandler.SetDirectForAllRenderers(2);
            return;
        }
        else if (WS == 0 && AD == -1)
        {
            _direction = left;
            _renderersHandler.SetDirectForAllRenderers(4);
            return;
        }
        else if (WS == 1 && AD == 0)
        {
            _direction = forvard;
            _renderersHandler.SetDirectForAllRenderers(1);
            return;
        }
        else if (WS == -1 && AD == 0)
        {
            _direction = back;
            _renderersHandler.SetDirectForAllRenderers(3);
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
                _renderersHandler.SetTakeoffOrLandForAllRenderers(FlyingStates.Flying);
            }
            else if (LandOrTakeoff == -1 && _stateManager.FlyingState == FlyingStates.Flying)
            {
                _renderersHandler.SetTakeoffOrLandForAllRenderers(FlyingStates.Landed);
            }
        }
    }
}
