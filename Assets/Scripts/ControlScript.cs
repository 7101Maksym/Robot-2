using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oFireRenderersController : MonoBehaviour
{
    private Animator _animator;
    private StateManager _stateManager;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
    }

    public void Shoot()
    {
        if (_stateManager.GunState == GunStates.Flamethrover_vertical)
        {
            if (_animator.GetFloat("HorizontalOrVertical") == 0f)
            {
                _animator.SetFloat("HorizontalOrVertical", 1f);
                StartCoroutine(StopShoot());
            }
        }
        else if (_stateManager.GunState == GunStates.Flamethrover_horizontal)
        {
            if (_animator.GetFloat("HorizontalOrVertical") == 0f)
            {
                _animator.SetFloat("HorizontalOrVertical", -1f);
                StartCoroutine(StopShoot());
            }
        }
    }

    private IEnumerator StopShoot()
    {
        yield return new WaitForSeconds(3f);

        _animator.SetFloat("HorizontalOrVertical", 0f);
    }
}