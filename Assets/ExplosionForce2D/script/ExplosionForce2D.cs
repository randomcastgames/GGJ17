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

# if (UNITY_EDITOR || UNITY_WEBPLAYER)

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;

            RaycastHit2D hit = Physics2D.Raycast(GetComponent<Rigidbody2D>().transform.position,Camera.main.ScreenToWorldPoint(mousePos));
            
            if (hit){
                AddExplosionForce(GetComponent<Rigidbody2D>(), Power * 100, hit.point, Radius);
                GameObject exp = Instantiate(explosion);
                exp.transform.position = hit.point;
            }
        }
# endif	
	
		}

		public static void AddExplosionForce (Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
		{
				var dir = (body.transform.position - expPosition);
				float calc = 1 - (dir.magnitude / expRadius);
				if (calc <= 0) {
						calc = 0;		
				}

				body.AddForce (dir.normalized * expForce * calc);
		}


}
