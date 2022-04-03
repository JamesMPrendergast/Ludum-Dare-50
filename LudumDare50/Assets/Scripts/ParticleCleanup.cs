using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script deletes ParticleSystems once they're not needed.
public class ParticleCleanup : MonoBehaviour
{

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2.0f)
        {
            Destroy(gameObject);
        }
    }
}
