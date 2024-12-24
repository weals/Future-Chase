using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Qihui Wang
public class CameraController : MonoBehaviour
{
    private GameObject player;
    public float followSpeed = 100f;
    public float rotationSpeed = 5f;

    private Vector3 offset;

    public string followTag = "Player";

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(followTag);
        offset = transform.position - player.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = player.transform.position + player.transform.TransformDirection(offset);

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
