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
    public float completionTime;
    public float completionReward;
    public float decayMultiplier;

    public GameObject ps; //confetti
    private GameObject InstantiatedPS;

    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        //assign random position from list of possible ones
        transform.position = positionList[Random.Range(0, positionList.Length)];
        timer = 0.0f;

        renderer = transform.GetChild(0).GetComponent<Renderer>();

        //print(ps);
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraController.current.taskBeingSolved != transform) { timer += Time.deltaTime; }
        if (timer >= expirationThreshold)
        {
            //task expires
            InevitabilityBar.current.ChangeInevitability(expirationPenalty);
            Destroy(gameObject);
        }

        //natural inevitability decay:
        if (CameraController.current.taskBeingSolved != transform) { InevitabilityBar.current.ChangeInevitability(decayMultiplier * Time.deltaTime); }

        //display how long a task was present
        float alpha = Mathf.Lerp(100.0f, 1.0f, timer / expirationThreshold);
        //Debug.Log(alpha + " vs " + alpha / 100);
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alpha / 100);
    }

    public void TaskCleared()
    {
        //task complete
        InevitabilityBar.current.ChangeInevitability(completionReward);

        //boost
        PlayerController.current.tempBoost(2.5f, 2.5f);

        //confetti!
        InstantiatedPS = Instantiate(ps, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        InstantiatedPS.transform.Rotate(new Vector3(270, 0, 0));
        Destroy(gameObject);
    }
}
