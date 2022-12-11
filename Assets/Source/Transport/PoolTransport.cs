using System.Collections.Generic;
using UnityEngine;

public class PoolTransport
{
    private List<Transport> _transports;
    private Transport _prefab;

    public PoolTransport(int countItems, Transport prefab)
    {
        _transports = new List<Transport>();

        _prefab = prefab;

        CreatePool(countItems);
    }

    private void CreatePool(int countItems)
    {
        for(int i = 0; i < countItems; i++)
        {
            this.AddItem();
        }
    }

    private Transport CreateItem()
    {
       return MonoBehaviour.Instantiate<Transport>(_prefab);
    }

    public Transport AddItem()
    {
        Transport item = CreateItem();

        item.gameObject.SetActive(false);

        _transports.Add(item);

        return item;
    }

    public bool HasFreeItem(out Transport item)
    {
        item = null;

        if (_transports.Count != 0) 
        {
            foreach (var transport in _transports)
            {
                if (!transport.gameObject.activeInHierarchy)
                {
                    item = transport;

                    return true;
                }
            }
        }

        return false;
    }

    public Transport[] GetActiveItems()
    {
       List<Transport> activeTransports = _transports.FindAll(
           transport => transport.gameObject.activeInHierarchy);

        return activeTransports.ToArray();
    }
}
