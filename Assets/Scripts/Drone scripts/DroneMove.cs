using UnityEngine;

public class DroneMove : MonoBehaviour
{
    private Rigidbody2D _rb;

    private Vector2 forvard, back, left, right;
    private Vector2 _direction;
    private int WS, AD;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        forvard = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        forvard = forvard.normalized;
        back = -forvard.normalized;
        right = Vector2.Perpendicular(forvard).normalized;
        left = -right;
    }

    private void FixedUpdate()
    {
        SetDirectionInPricess();
        _rb.velocity = _direction * 5f;
    }

    private void SetDirectionInPricess()
    {
        if (WS == 0 && AD == 0)
        {
            _direction = Vector2.zero;
            return;
        }
        else if (WS == 0 && AD == 1)
        {
            _direction = right;
        }
        else if (WS == 0 && AD == -1)
        {
            _direction = left;
        }
        else if (WS == 1 && AD == 0)
        {
            _direction = back;
        }
        else if (WS == -1 && AD == 0)
        {
            _direction = forvard;
        }
        else if (WS == 1 && AD == 1)
        {
            _direction = (back + right).normalized;
        }
        else if (WS == 1 && AD == -1)
        {
            _direction = (back + left).normalized;
        }
        else if (WS == -1 && AD == 1)
        {
            _direction = (forvard + right).normalized;
        }
        else if (WS == -1 && AD == -1)
        {
            _direction = (forvard + left).normalized;
        }
    }

    public void SetDirection(int WS, int AD)
    {
        this.WS = WS;
        this.AD = AD;
    }
}
