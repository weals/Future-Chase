using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleList : MonoBehaviour
{
    public List<GameObject> vehicles;
    public List<string> descriptions = new List<string>{
        "The Striker - A sleek, lightweight machine built for pure speed",
        "The Drifter - A playful machine designed for controlled chaos",
        "The Technician - A well-balanced machine built for consistent performance",
        "The Juggernaut - A heavy-duty machine built for durability and power"
    };

}
