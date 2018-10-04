using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //picks a random lane to spawn in
        int lane = Random.Range(-1, 2);
        //sets lane
        transform.position = new Vector3(transform.position.x + lane, transform.position.y, transform.position.z);
	}

    private void FixedUpdate()
    {
        //moves enemy car down the lane
        transform.position += -Vector3.forward * (Time.deltaTime * GameController.enemySpeed);
    }

    private void Update()
    {
        //self destruct when off the screen
        if (transform.position.z < -6)
        {
            Die();
        }
    }

    private void Die()
    {
        //increment GC counter and destroy object
        GameController.carsDodged++;
        Destroy(gameObject);
    }
}
