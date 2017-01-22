using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BulletController : MonoBehaviour
{

    public float bulletSpeed;
    public bool launch = false;

    private Vector2 normalHit;

    /// <summary>
    /// Variável para podermos editar a posição mais facilmente
    /// </summary>
    Vector3 myPosition;
    Vector3 target;

    /// <summary>
    /// Destruir o objeto quando ele se tornar invisivel 
    /// Essa função é chamada pelos componentes SpriteRenderer, MeshRenderer ou similares, quando o objeto deixa de ser visivel por todas as cameras - incluindo a camera do editor.
    /// </summary>
    void OnBecameInvisible()
    {
        if (gameObject.activeSelf == true)
            StartCoroutine("DisableAfter", 1);
    }

    IEnumerator DisableAfter(float interval)
    {
        yield return new WaitForSeconds(interval);
        gameObject.SetActive(false);
    }

    public void MoveTo(RaycastHit2D dir)
    {
        //target = dir*1.10f;
        //transform.DOMove(pos*1.20f, bulletSpeed);
        GetComponent<Rigidbody2D>().AddForce(-((Vector3)dir.point-transform.position) * bulletSpeed);
        normalHit = dir.normal;
    }

    public void OnCollisionEnter2D(Collision2D myCollision)
    {
        if ((myCollision.gameObject.tag != "Player") && (myCollision.gameObject.tag != "bullet"))
        {
            GameObject.Find("Player").GetComponent<ExplosionForce2D>().AddExplosionForce(myCollision.transform.position, normalHit);
            CameraShake.instance.Shake();

            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!launch) return;

        //Pega a posição
        myPosition = transform.position;

        myPosition = Vector3.MoveTowards(myPosition, target, 1000.0f);

        //myPosition.x += bulletSpeed * Time.deltaTime;
        //myPosition.y += bulletSpeed * Time.deltaTime;

        //Adicionar um valor à direita da bala ( X positivo ), fazendo com que ela se mova
        //myPosition.x += bulletSpeed * (float)Math.Sin(transform.rotation.eulerAngles.z) * Time.deltaTime;
        //myPosition.y += bulletSpeed * (float)Math.Cos(transform.rotation.eulerAngles.z) * Time.deltaTime;


        //Aplica a posição
        //transform.position = myPosition;
    }
}
