using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Transport : MonoBehaviour, IPause
{
    [SerializeField] private float _speed;

    private Rigidbody _transportRigidbody;
    private bool _isPause = false;

    private void OnValidate()
    {
        if(_speed == 0f)
        {
            _speed = 1f;
        }
    }

    private void Start()
    {
        _transportRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(!_isPause)
            _transportRigidbody.MovePosition(transform.position + transform.forward * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerView player))
        {
            _speed = 0f;
        }
    }

    public void SetPause()
    {
        _isPause = true;
    }

    public void UnPause()
    {
        _isPause = false;
    }
}
