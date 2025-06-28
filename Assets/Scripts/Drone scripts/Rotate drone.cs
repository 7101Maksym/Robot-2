using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatedrone : MonoBehaviour
{
    [SerializeField] private SpriteRenderer R000;
    [SerializeField] private SpriteRenderer R022;
    [SerializeField] private SpriteRenderer R045;
    [SerializeField] private SpriteRenderer R067;
    [SerializeField] private SpriteRenderer R090;
    [SerializeField] private SpriteRenderer R112;
    [SerializeField] private SpriteRenderer R135;
    [SerializeField] private SpriteRenderer R157;
    [SerializeField] private SpriteRenderer R180;
    [SerializeField] private SpriteRenderer R202;
    [SerializeField] private SpriteRenderer R225;
    [SerializeField] private SpriteRenderer R247;
    [SerializeField] private SpriteRenderer R270;
    [SerializeField] private SpriteRenderer R292;
    [SerializeField] private SpriteRenderer R315;
    [SerializeField] private SpriteRenderer R337;

    private StateManager _stateManager;
    private FireRenderersController _renderersController;

    private readonly int[] angles = { 0, 22, 45, 67, 90, 112, 135, 157, 180, 202, 225, 247, 270, 292, 315, 337, 360 };

    private int angle = 0, nowAngle;

    private void Awake()
    {
        _stateManager = GetComponent<StateManager>();
        _renderersController = GetComponentInChildren<FireRenderersController>();
    }

    private void DontVisibleAll()
    {
        R000.enabled = false;
        R022.enabled = false;
        R045.enabled = false;
        R067.enabled = false;
        R090.enabled = false;
        R112.enabled = false;
        R135.enabled = false;
        R157.enabled = false;
        R180.enabled = false;
        R202.enabled = false;
        R225.enabled = false;
        R247.enabled = false;
        R270.enabled = false;
        R292.enabled = false;
        R315.enabled = false;
        R337.enabled = false;
    }

    private void GetAngle(float angle)
    {
        if (angle < 0)
        {
            angle = 180 + angle;
        }
        else if (angle > 0)
        {
            angle = -180 + angle;
        }
        else
        {
            angle = 180;
        }

        angle += 180f;

        for (int i = 0; i < angles.Length - 1; i++)
        {
            if (angle > angles[i])
            {
                this.angle = GetRotateAngle(angle, angles[i], angles[i + 1]);
            }
        }
    }

    private int GetRotateAngle(float angle, int min, int max)
    {
        if (angle >= min || angle <= max)
        {
            if (angle - min < max - angle)
            {
                return min;
            }
            else
            {
                return max;
            }
        }
        else if (angle < min)
        {
            return min;
        }
        else if (angle > max)
        {
            return max;
        }
        else
        {
            return 0;
        }
    }

    private int GetNowAngle()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dronePosition = transform.position;
        Vector2 vectorToMouse = mousePosition - dronePosition;

        float controlAngle;
        int angleToMouse = (int)Vector2.Angle(transform.up, vectorToMouse);

        controlAngle = Vector2.Angle(transform.right.normalized, new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y).normalized);

        if (controlAngle < 90)
        {
            return angleToMouse;
        }
        else if (controlAngle > 90)
        {
            return -angleToMouse;
        }
        else
        {
            if (mousePosition.y < dronePosition.y)
            {
                return -180;
            }
            else if (mousePosition.y > dronePosition.y)
            {
                return 0;
            }
        }

        return 0;
    }

    private void Update()
    {
        if (_stateManager.FlyingState == FlyingStates.Flying)
        {
            DontVisibleAll();

            nowAngle = GetNowAngle();

            GetAngle(nowAngle);
            _renderersController.angle = angle;

            switch (angle)
            {
                case 0:
                    R000.enabled = true;
                    break;
                case 22:
                    R022.enabled = true;
                    break;
                case 45:
                    R045.enabled = true;
                    break;
                case 67:
                    R067.enabled = true;
                    break;
                case 90:
                    R090.enabled = true;
                    break;
                case 112:
                    R112.enabled = true;
                    break;
                case 135:
                    R135.enabled = true;
                    break;
                case 157:
                    R157.enabled = true;
                    break;
                case 180:
                    R180.enabled = true;
                    break;
                case 202:
                    R202.enabled = true;
                    break;
                case 225:
                    R225.enabled = true;
                    break;
                case 247:
                    R247.enabled = true;
                    break;
                case 270:
                    R270.enabled = true;
                    break;
                case 292:
                    R292.enabled = true;
                    break;
                case 315:
                    R315.enabled = true;
                    break;
                case 337:
                    R337.enabled = true;
                    break;
                case 360:
                    R000.enabled = true;
                    break;
            }
        }
    }
}
