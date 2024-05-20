using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public GameObject swordHitbox;
    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Collider2D swordCollider;
    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();
    public bool canMove = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        swordCollider = swordHitbox.GetComponent<Collider2D>();
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {
                bool success = Trymove(movementInput);
                if (!success)
                {
                    success = Trymove(new Vector2(movementInput.x, 0));
                    if (!success)
                    {
                        success = Trymove(new Vector2(0, movementInput.y));
                    }
                }
                animator.SetBool("isMoving", success);

            }
            else
            {
                animator.SetBool("isMoving", false);
            }
            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", false);

            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", true);
            }
        }
    }
    private bool Trymove(Vector2 direction)
    {
        if (direction != Vector2.zero) {


            
                int count = rb.Cast(
                        direction,
                        movementFilter,
                        castCollision,
                        moveSpeed * Time.fixedDeltaTime + collisionOffset);
                if (count == 0)
                {
                    rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                    return true;
                }
                else
                {
                    return false;
                }

            }else
            {
                return false;
            }
        }

    void OnMove(InputValue movementValue)
            {
                movementInput = movementValue.Get<Vector2>();
            }
    void OnFire()
    {
        animator.SetTrigger("Attack");
        Debug.Log("Attack");
    }
    void LockMovement()
    {
        canMove = false;
    }
    void UnlockMovement()
    {
        canMove = true;
    }
        }
    


