// Developed by Ananda Gupta
// info@anandagupta.com
// http://anandagupta.com

using UnityEngine;
using System.Collections;

public class ExplosionForce2D : MonoBehaviour
{
	public float Power;
	public float Radius;
    public GameObject explosion;
    public GameObject trail;
    private GameObject currentTrail = null;

    // Use this for initialization
    void Start ()
		{

        }
	
		// Update is called once per frame
		void FixedUpdate ()
		{
# if (UNITY_ANDROID || UNITY_IPHONE)

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			Vector3 fingerPos = Input.GetTouch(0).position;
			fingerPos.z = 10;


            RaycastHit2D hit = Physics2D.Raycast(GetComponent<Rigidbody2D>().transform.position, Camera.main.ScreenToWorldPoint(fingerPos));

            if (hit)
            {
                AddExplosionForce(GetComponent<Rigidbody2D>(), Power * 100, hit.point, Radius);

                GameObject exp = Instantiate(explosion);
                exp.transform.position = hit.point;
            }
        }

# endif



        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;

            RaycastHit2D hit = Physics2D.Raycast(GetComponent<Rigidbody2D>().transform.position,Camera.main.ScreenToWorldPoint(mousePos));
            
            transform.GetComponent<PlayerController>().ShootTo(hit);
        }
	
		}

		public void AddExplosionForce (Vector3 expPosition,Vector2 normal)
		{
			var dir = (GetComponent<Rigidbody2D>().transform.position - expPosition);
			float calc = 1 - (dir.magnitude / Radius);
			if (calc <= 0) {
					calc = 0;		
			}
            float angle = 0f;
            if(normal.normalized.y > 0.9f)
            {
                angle = 0.0f;
            }
            else if(normal.normalized.y < -0.9f)
            {
                angle = 180.0f;
            }
            else if(normal.normalized.x > 0.9f)
            {
                angle = -90.0f;
            }
                else if(normal.normalized.x < -0.9f)
            {
                angle = 90.0f;
            }

            GameObject exp = Instantiate(explosion);
            exp.transform.position = expPosition;
            exp.transform.rotation = Quaternion.Euler(0.0f,0.0f, angle);
            GetComponent<Rigidbody2D>().AddForce (dir.normalized * Power * 100 * calc);

            StopCoroutine("DestroyTrail");
        
            if(currentTrail == null)
                currentTrail = Instantiate(trail);

            currentTrail.transform.position = transform.position;
            currentTrail.transform.parent = transform;
            currentTrail.transform.rotation = Quaternion.Euler(90.0f+90.0f * dir.normalized.x, 90.0f, -90.0f);

            StartCoroutine("DestroyTrail");
    }

    IEnumerator DestroyTrail()
    {
        yield return new WaitForSeconds(1.0f);

        Destroy(currentTrail);
        currentTrail = null;
    }


}
