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

    }


    void Update()
    {

    }

    [SerializeField] private SceneController _corect_items = null;
    [SerializeField] private GameObject[] get_item = null;
    [SerializeField] private GameObject[] get_item_destroy = null;
    [SerializeField] private GameObject[] items_button = null;

    private bool Item_Menu = false;

    public void ItemOnClick()
    {

        if (!Item_Menu)
        {
            transform.Find("ItemWindow").gameObject.SetActive(true);
            Item_Menu = true;

            for (int i = 0; i < _corect_items.items.Length; ++i)
            {
                if (_corect_items.items[i])
                {
                    get_item[i].SetActive(true);

                }
            }

        }
        else
        {
            transform.Find("ItemWindow").gameObject.SetActive(false);
            Item_Menu = false;

            for (int i = 0; i < _corect_items.items.Length; ++i)
            {
                if (_corect_items.items[i])
                {
                    get_item[i].SetActive(false);
                }
            }
        }
    }

    private bool item_view_window = false;
    public void OpenItemViewWindow()
    {
        if (!item_view_window)
        {
            transform.Find("Item_view_window").gameObject.SetActive(true);

            for (int i = 0; i < _corect_items.items.Length; ++i)
            {
                if (items_button[i])
                {
                    get_item_destroy[i].SetActive(true);
                }
            }

            item_view_window = true;
        }
    }

    public void CloseItemViewWindow()
    {
        transform.Find("Item_view_window").gameObject.SetActive(false);

        item_view_window = false;
    }
}
