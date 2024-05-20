using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public float swordDamage = 1f;
    public Collider2D swordCollider;
    public float knockbackForce = 500f;
    public Vector3 faceRight = new Vector3 (1, 0, 0);
    public Vector3 faceLeft = new Vector3 (-1, 0, 0);
    
    void Start()
    {
        if (swordCollider == null)
        {
            Debug.LogWarning("Sword Collider not set");
        }
    }
/*  void OnCollisionEnter2D(Collision2D col)
    {
        col.collider.SendMessage("OnHit", swordDamage);
        Debug.Log("dung slime");
    }*/
    private void OnTriggerEnter2D(Collider2D col)
    {
        IDamageable damageableObject = col.GetComponent<IDamageable>();
        if (damageableObject != null) {
            Vector3 parentPosition = transform.parent.position;
            Vector2 direction = (Vector2) (col.gameObject.transform.position - parentPosition).normalized;
        Vector2 knockback = direction * knockbackForce;
        if (col.gameObject.layer.ToString() == "7")
        {
            try
            {
                //col.GetComponent<Collider2D>().SendMessage("OnHit", swordDamage, knockback); //swordDamage
                damageableObject.OnHit(swordDamage, knockback);
            }
            catch { }
        }
        }
        else
        {
      //      Debug.LogWarning("Collider does not implement IDamageable");
        }
    }
    void IsFacingRight(bool isFacingRight)
    {
        if (isFacingRight)
        {
            gameObject.transform.localPosition = faceRight;
        }
        else
        {
            gameObject.transform.localPosition = faceLeft;
        }
    }

}
