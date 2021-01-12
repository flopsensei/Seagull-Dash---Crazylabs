using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject _pooledObject;

    public int _pooledAmount;

    List<GameObject> _pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
        _pooledObjects = new List<GameObject>();

        for(int i = 0; i < _pooledAmount; i++ )
        {
            GameObject obj = (GameObject)Instantiate(_pooledObject);
            obj.SetActive(false);
            _pooledObjects.Add(obj);

        }
        
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < _pooledObjects.Count; i++)
        {
            if(!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(_pooledObject);
        obj.SetActive(false);
        _pooledObjects.Add(obj);
        return obj;
    }
}
