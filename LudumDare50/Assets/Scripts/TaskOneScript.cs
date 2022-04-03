using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script automatically initializes Task1
public class TaskOneScript : MonoBehaviour
{
    public Vector3[] positionList = {
        new Vector3(3, 0, 1),
        new Vector3(0, 0, 9.75f),
        new Vector3(-9.5f, 0, 4.25f),
        new Vector3(-17.5f, 0, 2),
        new Vector3(-13f, 0, 15.25f),
        new Vector3(4.5f, 0, 12.5f)
    };

    private float timer;
    //time until task expires
    public float expirationThreshold = 5.0f;

    public float expirationPenalty;
    public float completionReward;
    public float decayMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        //assign random position from list of possible ones
        transform.position = positionList[Random.Range(0, positionList.Length)];
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= expirationThreshold)
        {
            //task expires
            InevitabilityBar.current.ChangeInevitability(expirationPenalty);
            Destroy(gameObject);
        }

        //natural inevitability decay:
        InevitabilityBar.current.ChangeInevitability(decayMultiplier*Time.deltaTime);
    }

    public void TaskCleared()
    {
        //task complete
        InevitabilityBar.current.ChangeInevitability(completionReward);
        Destroy(gameObject);
    }
}
