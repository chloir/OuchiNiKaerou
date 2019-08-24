using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    [SerializeField] private GameObject button = null;
    
    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
    }

    public void OnMouseEnter()
    {
        button.SetActive(true);
    }

    public void OnMouseExit()
    {
        button.SetActive(false);
    }
}
