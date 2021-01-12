using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCreator : MonoBehaviour
{
    public GameObject _theCollectible;
    public Transform _genPoint;
    [SerializeField] private float _zedOffset;
    [SerializeField] private float _collectableHeight;

    [SerializeField] private float _leftHorizontalChange;
    [SerializeField] private float _rightHorizontalChange;

    private float _leftEdgeplacement;
    public Transform _leftEdgePoint;
    private float _rightEdgeplacement;
    public Transform _rightEdgePoint;
    private float _horizontalChange;

    //public objectPooler _theObjectPool;

    private int _platformselector;
    public ObjectPooler[] _objectPoolers;

    // Start is called before the first frame update
    void Start()
    {
        _leftEdgeplacement = _leftEdgePoint.position.x;
        _rightEdgeplacement = _rightEdgePoint.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < _genPoint.position.z)
        {


            _horizontalChange = transform.position.x + Random.Range(_rightHorizontalChange, _leftHorizontalChange);

            if(_horizontalChange > _rightEdgeplacement)
            {
                _horizontalChange = _rightEdgeplacement;
            }
            else if (_horizontalChange < _leftEdgeplacement)
            {
                _horizontalChange = _leftEdgeplacement;
            }

            transform.position = new Vector3(_horizontalChange, _collectableHeight, transform.position.z + _zedOffset);

            _platformselector = Random.Range(0, _objectPoolers.Length);

            //Instantiate(_theplatform, transform.position, transform.rotation);
            GameObject newPlatform = _objectPoolers[_platformselector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

        }

    }
}
