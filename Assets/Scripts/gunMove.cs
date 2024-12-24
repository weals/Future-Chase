using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunMove : MonoBehaviour
{
        private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
                player = GameObject.FindGameObjectWithTag("Player");

                transform.SetParent(player.transform);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
    }
}
