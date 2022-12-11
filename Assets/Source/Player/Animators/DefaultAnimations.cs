using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DefaultAnimations : PlayerAnimator
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void PlayerIdle()
    {
        _animator.SetBool("IsMove", false);
    }

    public override void PlayerMove()
    {
        _animator.SetBool("IsMove", true);
    }

    public override void PlayerDie()
    {
        _animator.SetBool("IsDie", true);
    }
}
