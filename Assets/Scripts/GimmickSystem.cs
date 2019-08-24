using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GimmickSystem : MonoBehaviour
{
    [SerializeField] private SceneController _controller = null;
    [SerializeField] private int pcPassword = 01200218;
    [SerializeField] private GameObject f = null;

    private void Start()
    {
        f.SetActive(false);
    }

    public void PCMystery()
    {
        f.SetActive(true);
        
        int playerInput = 0;
        int correctPassword = pcPassword;

        if (_controller.GetState() == SceneController.PlayerState.Cat)
        {
            if (playerInput == correctPassword)
            {
                Debug.Log("解除！");
            }
            else
            {
                f.GetComponent<InputField>().text = "違う";
            }
        }
    }

    public void MagazineGimmick()
    {
        _controller.items[0] = true;
        Destroy(gameObject);
    }
}
