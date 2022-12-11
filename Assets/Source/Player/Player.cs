using System;

public class Player
{
    private float _speed;

    private readonly float _maxSpeed = 10f;

    private readonly float _minSpeed = 0f;

    public float Speed => _speed;

    public event Action<float> OnSpeedChange;

    public Player(float speed)
    {
        _speed = speed;
    }

    public void TryAddSpeed(float speed)
    {
        _speed += speed;

        if (_speed > _maxSpeed)
            _speed = _maxSpeed;

        OnSpeedChange?.Invoke(_speed);
    }

    public void TryReduceSpeed(float speed)
    {
        _speed -= speed;

        if (_speed < _minSpeed)
            _speed = _minSpeed;

        OnSpeedChange?.Invoke(_speed);
    }

    public void PlayerDie()
    {
        _speed = 0f;
    }
}
