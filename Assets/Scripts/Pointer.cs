using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public event Action ChangeGoal;
    public GameObject Goal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeGoal != null)
            ChangeGoal();
        this.transform.LookAt(Goal.transform.position);
    }
}
