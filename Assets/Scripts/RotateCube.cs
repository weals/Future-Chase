using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Xisheng Zhang
public class RotateCube : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
