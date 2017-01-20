using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popcorn : Trap {
    [SerializeField] int minPopTime;
    [SerializeField] int maxPopTime;
    [SerializeField] int maxForce;

    bool pop = false;
    bool popping = false;
    
    Rigidbody body;

	// Use this for initialization
	void Start () {
        Invoke("Pop", Random.Range(minPopTime, maxPopTime));
        body = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {
        if (pop)
        {
            body.freezeRotation = false;
            pop = false;
            popping = true;
            body.AddForce(transform.up * maxForce);

            Invoke("Die", 3);
        }
    }

    void Pop() {
        pop = true;
        body.isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (popping)
          //  body.AddForce(new Vector3(getDirection(), getDirection(), getDirection()) * maxForce);
    }

    private float getDirection()
    {
        int d = Random.Range(0, 2);
        if (d == 0)
        {
            return Random.Range(-0.7f, -1f);
        }
        else
        {
            return Random.Range(0.7f, 1f);
        }
    }
}
