using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Qihui Wang
public class CoinCollector : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0,0,50) * Time.deltaTime);
    }

    
}
