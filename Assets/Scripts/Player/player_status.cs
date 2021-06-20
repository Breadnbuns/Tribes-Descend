using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_status : MonoBehaviour
{
    public int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            die();
        }
    }

    void die()
    {

    }
}
