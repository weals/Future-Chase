using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{

    public float amount = 1.0f;

    private Rigidbody bulletRigidbody;
    void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();

    }
    // Start is called before the first frame update
    void Start()
    {
        float speed = 100f;
        bulletRigidbody.velocity = transform.forward * speed;

    }

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") || other.CompareTag("Obstacle"))
        {

        }
        else if (other.CompareTag("AI"))
        {

            PlayerController aiController = other.GetComponent<PlayerController>();

            // Check if the AIController component is found on the other object
            if (aiController != null && aiController.maxSpeed > 21f)
            {
                // Modify the maxSpeed variable
                aiController.maxSpeed -= PlayerPrefs.GetFloat("damage");

            }
            Destroy(gameObject);
        }
        else
        {

            Destroy(gameObject);

        }
    }



}
