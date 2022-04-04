using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private float timer;

    public float TimeUntilT1; //time until task 1 is triggered
    public float TimeUntilT2; //time until task 2 is triggered
    public GameObject t1; //Task 1 to spawn
    public GameObject t2; //Task 2 to spawn

    public float t1mintime = 10.0f;
    public float t1maxtime = 20.0f;
    public float t2mintime = 30.0f;
    public float t2maxtime = 40.0f;

    public List<GameObject> tasks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        TimeUntilT1 = Random.Range(5.0f, 15.0f);
        TimeUntilT2 = Random.Range(20.0f, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        TimeUntilT1 -= Time.deltaTime;
        TimeUntilT2 -= Time.deltaTime;

        if (TimeUntilT1 <= 0)
        {
            Instantiate(t1);
            //this is where we would actually spawn task 1
            TimeUntilT1 = Random.Range(t1mintime, t1maxtime);
        }

        if (TimeUntilT2 <= 0)
        {
            Instantiate(t2);
            //this is where we would actually spawn task 2
            TimeUntilT2 = Random.Range(t2mintime, t2maxtime);
        }

        if (timer > 30)
        {
            //tasks spawn faster over time
            timer = 0;
            t1mintime *= .9375f;
            t1maxtime *= .9375f;
            t2mintime *= .9375f;
            t2maxtime *= .9375f;
        }
    }
}
