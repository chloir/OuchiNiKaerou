using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_menu : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;

    private Transform []childobject;
    void Start()
    {
        foreach (Transform childTransform in parentObject.transform)
        {
            childTransform.gameObject.SetActive(false);
        }
        transform.Find("Item_memu_Text").gameObject.SetActive(true);
        transform.Find("アイテムアイコン").gameObject.SetActive(true);
    }

    void Update()
    {
        
    }

    private bool Item_Menu = false;
    public void ItemOnClick()
    {
        if (!Item_Menu)
        {
            transform.Find("ItemWindow").gameObject.SetActive(true);
            Item_Menu = true;
        }
        else
        {
            transform.Find("ItemWindow").gameObject.SetActive(false);
            Item_Menu = false;
        }
    }
}
