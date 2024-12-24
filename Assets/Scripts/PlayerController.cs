using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Cinemachine;
// Author: Xisheng Zhang

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 70f;
    
    public float acceleration = 10f;

    [SerializeField] private AudioSource playSounds;

    public float currentSpeed = 0f;

    public float deceleration = 8f;
    public float turnSpeed = 350f;

    public float brakingForce = 20f;
    public float maxReverseSpeed = 30f;
    private Rigidbody rb;
    public float movementX;
    public float movementY;
    public int count;

    private float elapsedTime = 0f;

    public Transform BulletProj;
    public Transform SpawnBulletPosition;
    private Transform cameraTransform;
    private bool isBraking = false;
    private bool isControlEnabled = true;

    public LayerMask aimLayerMask = new LayerMask();
    public float fallThreshold = -5f;
    private PlayerInput playerInput;

    private InputAction lookAction;
    private InputAction fireAction;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        count = 0;
        if (gameObject.CompareTag("Player"))
        {
            maxSpeed = PlayerPrefs.GetFloat("speed");
        }
        else if (gameObject.CompareTag("AI"))
        {
            maxSpeed = PlayerPrefs.GetFloat("aiSpeed");
        }
    }

    void Update()
    {
                elapsedTime += Time.deltaTime;

    }

    void OnMove(InputValue movementValue)
    {
        if (!isControlEnabled) return;
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

        isBraking = movementY < 0;
    }

  

    void FixedUpdate()
    {
        if (!isControlEnabled) return;
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
        HandleAccelerationAndBraking();

        /*
            if (gameObject.CompareTag("Player")) {

            float targetAngle = cameraTransform.eulerAngles.y;

            Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime); 

                        HandleTurn();

            }
            else {
            }
              */

        HandleTurn();

        if (gameObject.CompareTag("Player"))
        {
            Vector3 mouseWorldPosition = Input.mousePosition;

            Vector2 screenPoint = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);

            Ray ray = Camera.main.ScreenPointToRay(screenPoint);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, 99999f, aimLayerMask))
            {

                mouseWorldPosition = raycastHit.point;
            }

            if (elapsedTime >= 8f && Input.GetMouseButtonDown(0))
            {
                Vector3 aimDir = (mouseWorldPosition - SpawnBulletPosition.position).normalized;
                Instantiate(BulletProj, SpawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            }
        }

        if (gameObject.CompareTag("AI")) {


            if (maxSpeed < 15f) {
                maxSpeed += .01f;
            } else if (maxSpeed > 30f) {
                maxSpeed = 30f;
            }
        }


    }



    void HandleAccelerationAndBraking()
    {
        if (movementY > 0)
        {
            if (currentSpeed < 0)
            {
                currentSpeed += brakingForce * Time.fixedDeltaTime;
            }
            else
            {
                currentSpeed += acceleration * Time.fixedDeltaTime;
            }
        }
        else if (isBraking)
        {
            if (currentSpeed <= 0)
            {
                currentSpeed -= acceleration * Time.fixedDeltaTime;
            }
            else
            {
                currentSpeed -= brakingForce * Time.fixedDeltaTime;
            }
        }
        else if (movementY == 0 && !isBraking)
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= deceleration * Time.fixedDeltaTime;
            }
            else if (currentSpeed < 0)
            {
                currentSpeed += deceleration * Time.fixedDeltaTime;
            }
        }

        if (currentSpeed > 0)
        {
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        }
        else
        {
            currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, 0);
        }

        Vector3 movement = transform.forward * currentSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);
    }

    void HandleTurn()
    {
        if (Mathf.Abs(currentSpeed) > 0.1f)
        {
            float turnDirection = currentSpeed > 0 ? 1f : -1f;
            float turn = movementX * turnDirection * turnSpeed * Time.fixedDeltaTime * 2f;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            FindObjectOfType<ScoreUpdate>().AddScore(count);
            playSounds.volume = 3.0f;
            playSounds.Play();
        }
        if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Obstacle"))
        {
            currentSpeed = 0.0f;
        }
    }

    public void SetPlayerControlEnabled(bool isEnabled)
    {
        isControlEnabled = isEnabled;
    }

    public Transform GetLastCheckpoint()
    {
        if (gameObject.CompareTag("Player"))
        {
            return RaceManager.PlayerCheckpointTransform;
        }
        else if (gameObject.CompareTag("AI"))
        {
            return RaceManager.AICheckpointTransform;
        }

        return null;
    }

    private void Respawn()
    {
        Transform lastCheckpoint = GetLastCheckpoint();
        Debug.Log("Respawning at checkpoint: " + lastCheckpoint);
        if (lastCheckpoint != null)
        {
            rb.MovePosition(lastCheckpoint.position);
            rb.MoveRotation(lastCheckpoint.rotation);

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            movementX = 0;
            movementY = 0;
            currentSpeed = 0;
        }
        else
        {
            Debug.Log("No checkpoint found");
        }
    }

}
