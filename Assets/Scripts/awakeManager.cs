using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class awakeManager : MonoBehaviour
{
    private List<GameObject> vehicles;
    private List<string> descriptions;
    public vehicleList vehicleList;
    public GameObject toRotate;
    public GameObject currentPlayer;
    public float rotateSpeed;
    public int vehiclePointer = 0;
    public GameObject startObject;
    public TMPro.TextMeshProUGUI descriptionText;

    

    private void Awake()
    {
        PlayerPrefs.SetInt("pointer", 0);
        vehicles = vehicleList.vehicles;
        descriptions = vehicleList.descriptions;
        vehiclePointer = PlayerPrefs.GetInt("pointer");
        currentPlayer = Instantiate(vehicles[vehiclePointer], startObject.transform.position, startObject.transform.rotation, toRotate.transform);
        currentPlayer.transform.localScale = startObject.transform.localScale;
        descriptionText = GameObject.Find("Description").GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void rightButton()
    {

        if (vehiclePointer < vehicles.Count - 1)
        {
            Destroy(currentPlayer);
            vehiclePointer++;
            PlayerPrefs.SetInt("pointer", vehiclePointer);
            currentPlayer = Instantiate(vehicles[vehiclePointer], startObject.transform.position, startObject.transform.rotation, toRotate.transform);
            currentPlayer.transform.localScale = startObject.transform.localScale;
            descriptionText.text = descriptions[vehiclePointer];
        }
    }

    public void leftButton()
    {

        if (vehiclePointer > 0)
        {
            Destroy(currentPlayer);
            vehiclePointer--;
            PlayerPrefs.SetInt("pointer", vehiclePointer);
            currentPlayer = Instantiate(vehicles[vehiclePointer], startObject.transform.position, startObject.transform.rotation, toRotate.transform);
            currentPlayer.transform.localScale = startObject.transform.localScale;
            descriptionText.text = descriptions[vehiclePointer];
        }
    }

    private void FixedUpdate()
    {
        toRotate.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    public void startGame()
    {
        SceneManager.LoadScene("First_Scene");
    }

}
