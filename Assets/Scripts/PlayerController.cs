using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower;

    Rigidbody2D myRigidyBody;

    SpriteAnimation currentAnimation;
    SpriteRenderer spriteRenderer;

    private bool grounded = true;

    public SpriteAnimation idleAnimation;
    public SpriteAnimation walkAnimation;
    public SpriteAnimation jumpAnimation;
    public SpriteAnimation fallAnimation;

    // Use this for initialization
    void OnEnable ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myRigidyBody = GetComponent<Rigidbody2D>();

        currentAnimation = idleAnimation;
        currentAnimation.StartAnimation();

    }
	
	// Update is called once per frame
	void Update () {
        /*if(!grounded && myRigidyBody.velocity.y == 0)
        {
            grounded = true;
        }*/

        if(!grounded)
        {
            //spriteAnimation.Fall();
        }

        GetMovementInput();
        Animate();
    }

    void GetMovementInput()
    {
        //spriteAnimation.SetIdle();

        if (Input.GetKey(KeyCode.D) == true)
        {
            spriteRenderer.flipX = false;

            myRigidyBody.AddForce(Vector2.right * speed);
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            spriteRenderer.flipX = true;

            myRigidyBody.AddForce(Vector2.left * speed);
        }

        if (Input.GetKey(KeyCode.Space) == true && grounded == true)
        {
            myRigidyBody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            grounded = false;
        }
    }

    void Animate()
    {
        if(myRigidyBody.velocity.x != 0.0f && grounded)
        {
            if (currentAnimation != walkAnimation)
            {
                currentAnimation.StopAnimation();

                currentAnimation = walkAnimation;
                currentAnimation.StartAnimation();
            }
        }
        else if(myRigidyBody.velocity.y > 0.0f && !grounded)
        {
            if (currentAnimation != jumpAnimation)
            {
                currentAnimation.StopAnimation();

                currentAnimation = jumpAnimation;
                currentAnimation.StartAnimation();
            }
        }
        else if (myRigidyBody.velocity.y < 0.0f && !grounded)
        {
            if (currentAnimation != fallAnimation)
            {
                currentAnimation.StopAnimation();

                currentAnimation = fallAnimation;
                currentAnimation.StartAnimation();
            }
        }
        else
        {
            if (currentAnimation != idleAnimation)
            {
                currentAnimation.StopAnimation();

                currentAnimation = idleAnimation;
                currentAnimation.StartAnimation();
            }
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("GameOver");
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }
}
