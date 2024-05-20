using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class Slime : MonoBehaviour, IDamageable
{
    public float damage = 1;
    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;
    bool isAlive = true;
    public float Health
    {
        set
        {
            if (value <= _health)
            {
                animator.SetTrigger("hit");
            }
            _health = value;

            if (_health <= 0)
            {
                animator.SetBool("isAlive", false);
                Targetable = false;
            }
        }
        get
        {
            return _health;
        }
    }

    public bool Targetable
    {
        get { return _targetable; }
        set
        {
            _targetable = value;
            rb.simulated = value;
            physicsCollider.enabled = value;
        }
    }

    public float _health = 3;
    public bool _targetable = true;
    public void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;
        //apply force to the slime
        rb.AddForce(knockback);
        Debug.Log("Force:" + knockback);
    }

    public void OnHit(float damage)
    {
        Health -= damage;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    /* void  OnCollisionEnter2D(Collision2D col)
    {
        IDamageable damageable = col.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.OnHit(damage);
        }
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            Debug.Log("takeDamae_2");
            try
            {
                PlayerHealth player = other.gameObject.GetComponentInParent<PlayerHealth>();
                player.TakeDamage(1f);
            }
            catch { }
        }
    }
    float speed = 3f;
    public void SlimeMove(Transform slime, Transform player)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);
    }
}