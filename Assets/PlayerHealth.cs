using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    ///=========================================/// <summary>
    /// =========================================///
    float _health = 3f;
    Animator playerAnimator;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("takeDamae_1");
        _health -= damage;
        if (_health <= 0)
        {
            StartCoroutine(PlayAnimAndDeath());
        }
    }

    IEnumerator PlayAnimAndDeath()
    {
        bool isDeath = false;
        if (!isDeath)
        {
            isDeath = true;
            GetComponent<PlayerController>().canMove = false;
            playerAnimator.SetBool("isDeath", true);
            yield return new WaitForSecondsRealtime(1f);
            PlayerDeath();
        }
    }
    void PlayerDeath()
    {
        this.gameObject.SetActive(false);
    }
}
