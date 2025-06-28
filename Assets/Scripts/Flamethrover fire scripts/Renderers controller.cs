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

    public int angle = 180;

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

    public void SetRenderer()
    {
        DontVisibleAll();

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
