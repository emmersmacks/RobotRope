using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private MovementController _characterController;
    [SerializeField] private Transform _player;

    private bool _isFreeze;
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _characterController = _player.GetComponent<MovementController>();
        _characterController.Dead += OnDead;
        _isFreeze = false;
    }

    private void Update()
    {
        if(!_isFreeze)
            transform.position = (Vector2)_player.position;
    }

    public void OnDead()
    {
        _isFreeze = true;
    }
}
