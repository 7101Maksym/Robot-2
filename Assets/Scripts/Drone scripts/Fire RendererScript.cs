using UnityEngine;

public class FireRendererScript : MonoBehaviour
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
            _animator.Play("Vertical");
            Invoke("StopShooting", 3f);
        }
        else if (_stateManager.GunState == GunStates.Flamethrover_horizontal)
        {
            _animator.Play("Horizontal");
            Invoke("StopShooting", 3f);
        }
        else
        {
            _animator.Play("DontFire");
        }
    }

    private void StopShooting()
    {
        _animator.Play("DontFire");
    }
}
