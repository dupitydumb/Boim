using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime; //Projectile life time

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy projectile after lifeTime
        Invoke ("DestroyProjectile", lifeTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
}
