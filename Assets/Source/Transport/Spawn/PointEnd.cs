using UnityEngine;

public class PointEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out Transport transport))
            transport.gameObject.SetActive(false);
        
    }
}
