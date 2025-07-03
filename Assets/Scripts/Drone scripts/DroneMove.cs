using UnityEngine;

public class DroneMove : MonoBehaviour
{
    private StateManager _stateManager;
    private Rigidbody2D _rb;
    private DroneRendererController _renderersHandler;

    private Vector2 forvard, back, left, right;
    private Vector2 _direction;
    private int WS, AD;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
        _renderersHandler = GetComponentInChildren<DroneRendererController>();
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
        if (_stateManager.MovingState == MovingStates.Move)
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
            return;
        }
        else if (WS == 0 && AD == 1)
        {
            _direction = right;
            return;
        }
        else if (WS == 0 && AD == -1)
        {
            _direction = left;
            return;
        }
        else if (WS == 1 && AD == 0)
        {
            _direction = forvard;
            return;
        }
        else if (WS == -1 && AD == 0)
        {
            _direction = back;
            return;
        }
    }

    public void SetDirection(int WS, int AD)
    {
        this.WS = WS;
        this.AD = AD;
    }
}
