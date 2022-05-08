using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    private InputController _controller;

    public AnimationState CurrentAnimation
    {
        get { return (AnimationState)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<InputController>();
    }

    private void Update()
    {
        if(_controller.currentState == CharacterState.isGrab)
        {
            CurrentAnimation = AnimationState.grab;
        }
        else if(_controller.currentState == CharacterState.isFree)
        {
            CurrentAnimation = AnimationState.idle;
        }
    }

    public enum AnimationState
    {
        idle,
        jump,
        grab,
    }
}
