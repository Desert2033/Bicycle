using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody), typeof(PlayerAnimator))]
public class PlayerView : MonoBehaviour, IPause
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private Transform _pizzaTransform;
 
    private Player _player;
    private Rigidbody _playerRigidbody;
    private float _speedAdd = 0.01f;
    private float _speedReduce = 0.01f;
    private bool _isPause = false;

    public event Action OnDie;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(_joystick.Horizontal > 0)
        {
            _player.TryAddSpeed(_speedAdd);
        }
        else if(_joystick.Horizontal < 0)
        {
            _player.TryReduceSpeed(_speedReduce);
        }
    }

    private void FixedUpdate()
    {
        if(!_isPause)
            this.Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out Transport transport))
        {
            _player.PlayerDie();

            _playerAnimator.PlayerDie();

            this.SetPause();
        }
        else if (collision.transform.TryGetComponent(out Finish finish))
        {
            finish.SetFinish(_pizzaTransform);

            this.SetPause();
        }
    }

    private void Move()
    {
        if(_player.Speed != 0)
        {
            _playerRigidbody.MovePosition(transform.position + transform.forward * _player.Speed * Time.deltaTime);

            _playerAnimator.PlayerMove();
        }
        else
        {
            _playerAnimator.PlayerIdle();
        }
    }

    public void Init(Player player)
    {
        _player = player;
    }

    public void OnDieEvent()
    {
        OnDie?.Invoke();
    }

    public void SetPause()
    {
        _playerRigidbody.isKinematic = true;

        _playerRigidbody.detectCollisions = false;

        _isPause = true;
    }

    public void UnPause()
    {
        _playerRigidbody.isKinematic = false;

        _playerRigidbody.detectCollisions = true;

        _isPause = false;
    }
}
