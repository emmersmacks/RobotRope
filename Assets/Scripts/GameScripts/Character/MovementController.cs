using UnityEngine;
using System;
using Zenject;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;

    [Inject] private PlayerData _data;

    private InputController characterController;
    private Rigidbody2D _rigidbody;
    private bool jetpackRun;

    public event Action MoneyCollect = default;
    public event Action Dead = default;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        characterController = GetComponent<InputController>();

        characterController.Hook += OnHook;
        characterController.Unhook += OnUnhook;
    }
    private void OnHook()
    {
        _rigidbody.gravityScale = 0f;
        jetpackRun = true;
    }

    private void OnUnhook()
    {
        _rigidbody.gravityScale = 0.8f;
        jetpackRun = false;
    }

    public void Update()
    {
        if(jetpackRun)
        {
            if (_rigidbody.velocity.magnitude < _speed)
                _rigidbody.AddForce(_rigidbody.velocity * _acceleration, ForceMode2D.Force);
        }
    }

    private void LateUpdate()
    {
        RotateToMoveDirection();
    }

    public void RotateToMoveDirection()
    {
        var vectorDot = Vector2.Dot(transform.right, _rigidbody.velocity);
        _rigidbody.MoveRotation(_rigidbody.rotation - vectorDot);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<MoneyScript>())
        {
            _data.data.money++;
            MoneyCollect();
        }
    }

    public void DeadAction()
    {

        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(new Vector2(10, 10), ForceMode2D.Impulse);
        characterController.currentState = CharacterState.isDead;
        Dead();
    }
}
