using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightSimControl : MonoBehaviour
{
    enum PlaneCondition
    {
        Fly,
        Start
    }

    PlaneCondition planeCondition;
    public float minSpeed = 50;
    public float maxSpeed = 150;
    public float speed = 0;
    public float deltaSpeed = 50;

    public event Action<FlightSimControl> InitGoal;

    private GameObject goal;
    // Start is called before the first frame update
    void Start()
    {
        planeCondition = PlaneCondition.Start;
    }

    // Update is called once per frame
    void Update()
    {
        speed -= transform.forward.y * deltaSpeed * Time.deltaTime;

        if (speed < minSpeed)
            speed = minSpeed;
        
        if (speed > maxSpeed)
            speed = maxSpeed;

        transform.position += transform.forward * Time.deltaTime * speed;

        transform.Rotate(-Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));

        var terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeightWhereWeAre > transform.position.y)
        {
            transform.position = new Vector3
                (
                    transform.position.x,
                    terrainHeightWhereWeAre,
                    transform.position.z
                );
        }
    }
}
