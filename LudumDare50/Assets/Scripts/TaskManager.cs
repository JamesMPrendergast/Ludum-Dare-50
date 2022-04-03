using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public float TimeUntilT1; //time until task 1 is triggered
    public float TimeUntilT2; //time until task 2 is triggered
    public GameObject t1; //Task 1 to spawn
    public GameObject t2; //Task 2 to spawn

    public List<GameObject> tasks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        TimeUntilT1 = Random.Range(20.0f, 30.0f);
        TimeUntilT2 = Random.Range(35.0f, 45.0f);
    }

    // Update is called once per frame
    void Update()
    {
        TimeUntilT1 -= Time.deltaTime;
        TimeUntilT2 -= Time.deltaTime;

        if (TimeUntilT1 <= 0)
        {
            Instantiate(t1);
            //this is where we would actually spawn task 1
            TimeUntilT1 = Random.Range(10.0f, 20.0f);
        }

        if (TimeUntilT2 <= 0)
        {
            Instantiate(t2);
            //this is where we would actually spawn task 2
            TimeUntilT2 = Random.Range(30.0f, 40.0f);
        }
    }
}
