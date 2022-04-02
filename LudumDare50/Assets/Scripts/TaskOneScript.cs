using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script automatically initializes Task1
public class TaskOneScript : MonoBehaviour
{
    Vector3[] positions = { new Vector3(2, 0, 2), new Vector3(0, 0, 2), new Vector3(-2, 0, 2) };

    // Start is called before the first frame update
    void Start()
    {
        //assign random position from list of possible ones
        transform.position = positions[Random.Range(0, 3)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
