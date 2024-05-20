using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePhatHien : MonoBehaviour
{
    public Slime slime;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject.name == "Player")
        {
           slime.SlimeMove(slime.transform, collision.transform);
        }
        //Debug.LogError(collision.gameObject.name);
    }

}
