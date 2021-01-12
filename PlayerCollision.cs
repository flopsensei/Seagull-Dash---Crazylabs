using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController _movement;

    void OnCollisionEnter (Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {

            _movement.enabled = false;

            FindObjectOfType<GameManager>().Endgame();
        }
    }
 
}
