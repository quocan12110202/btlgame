using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuongTac : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer.ToString());
        if(collision.gameObject.layer.ToString() == "6")
        {
            UIGame.Instance.ShowPopupChest();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer.ToString() == "6")
        {
            UIGame.Instance.HidePopupChest();
        }
    }
}
