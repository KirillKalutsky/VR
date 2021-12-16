using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;
    public Pointer Pointer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Столкновение");
    }

    private GameObject nextGoal;

    private void OnTriggerEnter(Collider other)
    {
        var x = Random.Range(-1000, 1000);
        var z = Random.Range(-1000, 1000);
        var y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z)) + Random.Range(2, 100);
        nextGoal = Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
        this.Pointer.ChangeGoal += ChangeGoal;
        Destroy(gameObject);
    }

    private void ChangeGoal()
    {
        Pointer.Goal = nextGoal;
    }
}
