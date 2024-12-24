using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{    float horizontalAngle;
    float verticalAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
        Vector3 mousePos = Input.mousePosition;
        mousePos.y = Screen.height - mousePos.y;

        horizontalAngle = Mathf.Lerp(-90f, 90f, mousePos.x / Screen.width);
        verticalAngle = Mathf.Lerp(-70f, 70f, mousePos.y / Screen.height);

        transform.rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f) * transform.parent.rotation;



    }
}
