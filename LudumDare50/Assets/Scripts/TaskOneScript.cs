using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script automatically initializes Task1
public class TaskOneScript : MonoBehaviour
{
    public Vector3[] positions = { new Vector3(2, 0, 2), new Vector3(0, 0, 2), new Vector3(-2, 0, 2) };
    private float timer;

    //time until task expires
    public float expirationThreshold = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        //assign random position from list of possible ones
        transform.position = positions[Random.Range(0, positions.Length)];
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= expirationThreshold)
        {
            //task expires
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //task complete
        Destroy(gameObject);
    }
}
