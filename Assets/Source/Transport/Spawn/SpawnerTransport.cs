using UnityEngine;

public class SpawnerTransport : MonoBehaviour, IPause
{
    [SerializeField] private Transform _pointStart;
    [SerializeField] private Transform _pointEnd;
    [SerializeField] private Transport _prefab;
    [SerializeField] private float _cooldownSpawn = 1f;

    private PoolTransport _poolTransport;
    private float _timerSec = 0f;
    private bool _isPause = false;

    private void Start()
    {
        _poolTransport = new PoolTransport(1, _prefab);

        _timerSec = _cooldownSpawn;
    }

    public void Update()
    {
        if (!_isPause)
        {
            if (_timerSec >= _cooldownSpawn)
            {
                this.Spawn();

                _timerSec = 0f;
            }
            else
            {
                _timerSec += Time.deltaTime;
            }
        }
    }

    private void Spawn()
    {
        Transport transport;

        if (!_poolTransport.HasFreeItem(out transport))
        {
            transport = _poolTransport.AddItem();
        }

        transport.transform.position = _pointStart.position;

        transport.transform.rotation = _pointStart.rotation;

        transport.gameObject.SetActive(true);
    }

    public void SetPause()
    {
        _isPause = true;

        foreach(var item in _poolTransport.GetActiveItems())
        {
            item.SetPause();
        }
    }

    public void UnPause()
    {
        _isPause = false;

        foreach (var item in _poolTransport.GetActiveItems())
        {
            item.UnPause();
        }
    }
}
