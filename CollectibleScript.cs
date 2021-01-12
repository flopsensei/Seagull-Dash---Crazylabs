using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public int _scoreValue;

    private ScoreManager _ThescoreManager;

    // Start is called before the first frame update
    void Start()
    {
        _ThescoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            _ThescoreManager._scoreCount += _scoreValue;
        }
    }
}
