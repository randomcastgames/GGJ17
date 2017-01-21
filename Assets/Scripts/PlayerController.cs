using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower;

    Vector3 myPosition;
    Vector3 myMovement;

    Rigidbody2D myRigidyBody;

    private bool grounded = true;

    // Use this for initialization
    void OnEnable () {
        myRigidyBody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        if(!grounded && myRigidyBody.velocity.y == 0)
        {
            grounded = true;
        }

        GetMovementInput();
    }

    void GetMovementInput()
    {
        if (Input.GetKey(KeyCode.D) == true)
        {
            myRigidyBody.AddForce(Vector2.right * speed);
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            myRigidyBody.AddForce(Vector2.left * speed);
        }

        if (Input.GetKey(KeyCode.Space) == true && grounded == true)
        {
            myRigidyBody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            grounded = false;
        }
    }
}
