using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altplatform_creater : MonoBehaviour
{
    public GameObject _theplatform;
    public Transform _genPoint;
    [SerializeField] private float _zedOffset;

    //public objectPooler _theObjectPool;

    private int _platformselector;
    public ObjectPooler[] _objectPoolers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < _genPoint.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _zedOffset);

            _platformselector = Random.Range(0, _objectPoolers.Length);

            //Instantiate(_theplatform, transform.position, transform.rotation);
            GameObject newPlatform =  _objectPoolers[_platformselector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

        }
        
    }
}
