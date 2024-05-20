using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
   public static UIGame Instance;

    public GameObject popupRuong;

    private void Start()
    {
        Instance = this;
    }
    public void ShowPopupChest()
    {
        popupRuong.SetActive(true);
    }
    public void HidePopupChest()
    {
        popupRuong.SetActive(false);
    }
}
