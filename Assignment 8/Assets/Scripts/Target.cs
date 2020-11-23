//Logan Ross
//Assignment 8
//Spawns items randomly and allows them to be destroyed on click and OOB

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    private GameManager gm;
    public int pointValue;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //add a force up multiplied by rand speed
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);

        //add torgue (rotational force) with rand xyz vals
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        //set pos with rand x value
        transform.position = RandomSpawnPos();
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private void OnMouseDown()
    {
        if (gm.isGameActive)
        {
            gm.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!gameObject.CompareTag("Bad"))
        {
            gm.GameOver();
        }
        Destroy(gameObject);    
    }
}
