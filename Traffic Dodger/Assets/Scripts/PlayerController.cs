using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public Vector3 newPos; //position the car will move to
    public static bool dead; //indicates if the player has died
    public bool LBut;
    public bool RBut;
    private bool boost;
    void Start () {
        //sets starting position
        newPos = transform.position;
        boost = false;
        dead = false;
	}

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //clamps car's position to within game screen
        Vector3 tmpPos = newPos;
        tmpPos.x = Mathf.Clamp(tmpPos.x, -2.0f, 2.0f);
        newPos = tmpPos;
        //moves car to appropriate lane
        transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * 10);
    }

    //moves car left by one lane
    public void MoveLeft()
    {
        newPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
    }
    //moves car right by one lane
    public void MoveRight()
    {
        newPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        dead = true;
    }
}
