using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    /* Start is called before the first frame update
    void Start()
    {
        if (Input.GetMouseButtonUp(0))     
            Debug.Log("押された!");
        
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            Debug.Log("押された!");

    }
}
