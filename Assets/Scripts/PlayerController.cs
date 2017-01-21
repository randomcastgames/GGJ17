using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower;

    Rigidbody2D myRigidyBody;

    SpriteRenderer mySpriteRenderer;

    private bool grounded = true;

    // Use this for initialization
    void OnEnable () {
        myRigidyBody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        /*if(!grounded && myRigidyBody.velocity.y == 0)
        {
            grounded = true;
        }*/

        GetMovementInput();

        if(!mySpriteRenderer.isVisible)
        {
            //Die();
        }
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

    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            this.grounded = true;
        }
    }
}
