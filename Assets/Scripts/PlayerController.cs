using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public float mouseThreshould;
    public int maxAmmo;
    public int currentAmmo;

    Rigidbody2D myRigidyBody;

    SpriteAnimation currentAnimation;
    SpriteRenderer spriteRenderer;

    private bool grounded = true;

    public SpriteAnimation idleAnimation;
    public SpriteAnimation walkAnimation;
    public SpriteAnimation jumpAnimation;
    public SpriteAnimation fallAnimation;

    GameObject rocketLauncher;

    // Use this for initialization
    void OnEnable ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myRigidyBody = GetComponent<Rigidbody2D>();

        rocketLauncher = transform.FindChild("Gun").gameObject;

        currentAnimation = idleAnimation;
        currentAnimation.StartAnimation();

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0) return;

        GetMovementInput();
        Animate();

        GameManager.instance.worldSpeed = Vector3.zero;

        if (transform.position.y > 0.0f && myRigidyBody.velocity.y > 0.0f)
        {
            GameManager.instance.worldSpeed = new Vector3(0.0f, -transform.position.y*Time.deltaTime, 0.0f);
        }
    }

    public void ShootTo(RaycastHit2D dir)
    {
        if (currentAmmo > 0)
        {
            //--currentAmmo;

            //Instancea a bala e guarda-a numa variável temporária
            GameObject currentBullet = PoolManager.instance.FindPool("BulletPool").ActivateGameObject();
            Physics2D.IgnoreCollision(currentBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            //Utiliza a variável temporária para setar a posição da bala ( a posição da bala será a posição da nave + uma unidade para a direita, para ela aparecer na frente da nave. )
            currentBullet.transform.position = rocketLauncher.transform.FindChild("BulletTrigger").transform.position;
            currentBullet.transform.rotation = rocketLauncher.transform.rotation;

            currentBullet.GetComponent<BulletController>().launch = true;

            /*Vector3 myPosition = currentBullet.transform.position;

            myPosition.x += 0.2f * (float)Math.Cos(currentBullet.transform.rotation.eulerAngles.z);
            myPosition.y += 0.2f * (float)Math.Sin(currentBullet.transform.rotation.eulerAngles.z);

            currentBullet.transform.position = myPosition;*/

            currentBullet.GetComponent<BulletController>().MoveTo(dir);
        }
    }

    void GetMovementInput()
    {
        if ((Input.GetKey(KeyCode.D) == true) || Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x + mouseThreshould)
        {
            spriteRenderer.flipX = false;

            if(Input.GetKey(KeyCode.D) == true)
                myRigidyBody.AddForce(Vector2.right * speed);
        }

        if (Input.GetKey(KeyCode.A) == true || Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x - mouseThreshould)
        {
            spriteRenderer.flipX = true;

            if (Input.GetKey(KeyCode.A))
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

        if (collision.gameObject.tag == "ammo")
        {
            if(currentAmmo < maxAmmo)
                ++currentAmmo;
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
