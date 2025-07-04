using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRenderersController : MonoBehaviour
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

    public int angle = 180;

    private void Awake()
    {
        _stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
    }

    public void DontVisibleAll()
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

    private void SetRendererAndShoot()
    {
        DontVisibleAll();

        _stateManager.MovingState = MovingStates.NotMove;

        switch (angle)
        {
            case 0:
                R000.enabled = true;
                R000.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 22:
                R022.enabled = true;
                R022.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 45:
                R045.enabled = true;
                R045.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 67:
                R067.enabled = true;
                R067.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 90:
                R090.enabled = true;
                R090.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 112:
                R112.enabled = true;
                R112.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 135:
                R135.enabled = true;
                R135.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 157:
                R157.enabled = true;
                R157.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 180:
                R180.enabled = true;
                R180.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 202:
                R202.enabled = true;
                R202.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 225:
                R225.enabled = true;
                R225.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 247:
                R247.enabled = true;
                R247.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 270:
                R270.enabled = true;
                R270.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 292:
                R292.enabled = true;
                R292.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 315:
                R315.enabled = true;
                R315.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 337:
                R337.enabled = true;
                R337.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
            case 360:
                R000.enabled = true;
                R000.gameObject.GetComponent<FireRendererScript>().Shoot();
                break;
        }

        Invoke(nameof(SetMoving), 3f);
    }

    private void SetMoving()
    {
        _stateManager.MovingState = MovingStates.Move;
        DontVisibleAll();
    }

    public void PlayShoot()
    {
        SetRendererAndShoot();
    }
}
