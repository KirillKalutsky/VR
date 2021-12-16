using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeController : MonoBehaviour
{
    public float Speed = 5;
    Rigidbody R;
    void Start()
    {
        R = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Speed += 0.00015f;
            var speedDirection = new Vector3(0, Speed, 0);
            R.AddForce(speedDirection);
            //R.MovePosition(R.position + speedDirection);
        }
        //else if (Speed > 0)
        //{
        //    Speed -= 0.0001f;
        //}

        
    }
}
