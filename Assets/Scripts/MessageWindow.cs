using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    [SerializeField] private string message01 = "";
    private Text messageText = null;

    // Start is called before the first frame update
    void Start()
    {
        messageText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
