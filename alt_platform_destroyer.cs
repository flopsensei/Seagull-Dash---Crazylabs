using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alt_platform_destroyer : MonoBehaviour
{
    public GameObject _platformdestroyer;

    // Start is called before the first frame update
    void Start()
    {
        _platformdestroyer = GameObject.Find ("distruction point");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < _platformdestroyer.transform.position.z)
        {
            gameObject.SetActive(false);
        }
    }
}
