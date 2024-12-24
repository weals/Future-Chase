using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public vehicleList list;
    public List<GameObject> vehicles;
    public GameObject startObject;
    public CinemachineVirtualCamera vcam; 

    private void Awake ()
    {
        vehicles = list.vehicles;
        int vehiclePointer = PlayerPrefs.GetInt("pointer");
        GameObject currPlayer = Instantiate(vehicles[vehiclePointer], startObject.transform.position, startObject.transform.rotation);
        currPlayer.transform.localScale = startObject.transform.localScale;
        currPlayer.tag = "Player";

        //find MiniMapTarget GameObject and set its parent to currPlayer
        GameObject miniMapTarget = GameObject.Find("MiniMapTarget");
        miniMapTarget.transform.SetParent(currPlayer.transform, false);
        Debug.Log("MiniMapTarget parent: " + miniMapTarget.transform.parent.name);


        // vcam.Follow = currPlayer.transform;
        // vcam.LookAt = currPlayer.transform;

        

        
    }
}
