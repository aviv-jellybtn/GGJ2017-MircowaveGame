using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popcorn : MonoBehaviour {
    [SerializeField] int minPopTime;
    [SerializeField] int maxPopTime;
    [SerializeField] int maxForce;
    [SerializeField] int level;
    Spawner spawner;
    bool pop = false;

    
    Rigidbody body;

	// Use this for initialization
	void Start () {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        Invoke("Pop", Random.Range(minPopTime, maxPopTime));
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {
        if (pop)
        {
            pop = false;
            body.AddForce(new Vector3(Random.Range(-1, 1),
                                      Random.Range(-1, 1),
                                      Random.Range(-1, 1)) * maxForce);

            Invoke("Die", 3);
        }
    }

    void Pop() {
        pop = true;
    }

    void Die()
    {
        spawner.killTrap(level);
    }
}
