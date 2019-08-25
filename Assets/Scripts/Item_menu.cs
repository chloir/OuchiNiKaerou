using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_menu : MonoBehaviour
{
    [SerializeField] private SceneController _get_items;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private GameObject[] get_items; 

    private Transform []childobject;
    void Start()
    {
        foreach (Transform childTransform in parentObject.transform)
        {
            childTransform.gameObject.SetActive(false);
        }
        transform.Find("ItemMenu").gameObject.SetActive(true);
    }

    void Update()
    {
        
    }

    private bool Item_Menu = false;
    public void ItemOnClick()
    {
        if (!Item_Menu)
        {
            transform.Find("Item holder").gameObject.SetActive(true);

            Item_Menu = true;
        }
        else
        {
            transform.Find("Item holder").gameObject.SetActive(false);
            Item_Menu = false;
        }
    }
}
