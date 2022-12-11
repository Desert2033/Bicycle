using UnityEngine;

public abstract class PlayerAnimator : MonoBehaviour
{
    public abstract void PlayerIdle();

    public abstract void PlayerMove();

    public abstract void PlayerDie();
}
