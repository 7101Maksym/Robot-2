using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firerendererscript : MonoBehaviour
{
    private FireRenderersController _renderersController;
    private StateManager _stateManager;
    private Animator _animator;

    private void Awake()
    {
        _renderersController = GetComponentInParent<FireRenderersController>();
        _stateManager = GetComponentInParent<StateManager>();
        _animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (_stateManager.ShootingState == ShootingStates.Shooting)
        {
            if (_stateManager.GunState == GunStates.Flamethrover_horizontal)
            {
                _renderersController.SetRenderer();
                _animator.Play("Horizontal");
            }
            else if (_stateManager.GunState == GunStates.Flamethrover_vertical)
            {
                _renderersController.SetRenderer();
                _animator.Play("Vertical");
            }
        }
        else
        {
            _renderersController.DontVisibleAll();
        }
    }
}
