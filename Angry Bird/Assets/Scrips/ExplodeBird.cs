using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBird : Bird
{
    public float Impact;

    public float force;

    public LayerMask LayerToHit;

    public GameObject ExplosionEffect;

    public float expl = 20;


    public override void OnCollisionEnter2D(Collision2D col)
    {
        explode();
    }

    void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, Impact, LayerToHit);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force * expl );

        }

        //GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        //Destroy(ExplosionEffectIns, 10);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Impact);

    }
}