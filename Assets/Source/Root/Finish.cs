using UnityEngine;
using System;

public class Finish : MonoBehaviour
{
    [SerializeField] private Transform _orderer;

    private Transform _pizza;

    public event Action OnFinish;

    public void SetFinish(Transform pizza)
    {
        _pizza = pizza;
        _pizza.SetParent(_orderer);
        _pizza.position = _orderer.position;

        OnFinish?.Invoke();
    }
}
