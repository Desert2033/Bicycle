using UnityEngine;

public class CameraFolllow : MonoBehaviour
{
    [SerializeField] private Transform _targetFollow;
    [SerializeField] private Vector3 offset;

    private Transform _newPosition;

    private void Start()
    {
        _newPosition = _targetFollow;
    }

    
    private void Update()
    {
        transform.position = _targetFollow.position + offset;
    }
}
