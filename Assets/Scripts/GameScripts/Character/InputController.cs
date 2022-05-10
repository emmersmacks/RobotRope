using UnityEngine;
using System;

namespace Ropebot.Game.Player.Controllers
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private float _firstJumpForce;
        [SerializeField] private Vector2 _firstJumpDirection;

        private Rigidbody2D _rigidbody;

        public Transform currentFastener;
        public bool canGrab;
        public CharacterState currentState;

        public event Action Hook = default;
        public event Action Unhook = default;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            currentState = CharacterState.inStart;
            canGrab = false;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && canGrab)
            {
                currentState = CharacterState.isGrab;
                Hook();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                currentState = CharacterState.isFree;
                Unhook();
            }
            else if (currentState == CharacterState.inStart)
            {
                if (Input.GetMouseButton(0))
                {
                    _rigidbody.AddForce(_firstJumpDirection * _firstJumpForce, ForceMode2D.Impulse);
                    currentState = CharacterState.isFree;
                }
            }

            if(Input.touchCount > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began && canGrab)
                {
                    currentState = CharacterState.isGrab;
                    Hook();
                }
                else if (Input.touches[0].phase == TouchPhase.Canceled)
                {
                    currentState = CharacterState.isFree;
                    Unhook();
                }
                else if (currentState == CharacterState.inStart)
                {
                    if (Input.GetMouseButton(0))
                    {
                        _rigidbody.AddForce(_firstJumpDirection * _firstJumpForce, ForceMode2D.Impulse);
                        currentState = CharacterState.isFree;
                    }
                }
            }
        }
    }
    public enum CharacterState
    {
        inStart,
        isGrab,
        isFree,
        isDead,
    }
}

