﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GimmickSystem : MonoBehaviour
{
    [SerializeField] private SceneController _controller = null;
    [SerializeField] private MessageWindow window = null;
    [SerializeField] private int pcPassword = 01200218;
    [FormerlySerializedAs("f")] [SerializeField] private GameObject pcGimmickInput = null;
    [SerializeField] private GameObject magazineObject = null;
    private bool pcIsOn = false;
    private bool pc1stGimmickCompleted = false;

    private void Start()
    {
        pcGimmickInput.SetActive(false);
    }

    public void PCPowerOn()
    {
        if (!pcIsOn && _controller.GetState() == SceneController.PlayerState.Dog)
        {
            pcIsOn = true;
            window.PcOnMessage();
        }
    }
    
    public void PCMystery()
    {
        if (_controller.GetState() == SceneController.PlayerState.Cat && pcIsOn)
        {
            pcGimmickInput.SetActive(true);
        }
    }

    public void PCInputOnComplete()
    {
        string playerInput = pcGimmickInput.GetComponent<InputField>().text;
        string correctPassword = pcPassword.ToString();
        
        if (_controller.GetState() == SceneController.PlayerState.Cat)
        {
            if (playerInput == correctPassword)
            {
                pcGimmickInput.GetComponent<InputField>().text = "解除";
            }
            else
            {
                pcGimmickInput.GetComponent<InputField>().text = "違う";
            }
        }
    }

    public void BelowBed()
    {
        if (_controller.GetState() == SceneController.PlayerState.Cat)
        {
            // Getシワシワの紙
        }
    }

    public void BelowTV()
    {
        if (_controller.GetState() == SceneController.PlayerState.Cockloach)
        {
            // テレビ下
        }
    }

    public void PosterGimmick()
    {
        
    }

    public void MagazineGimmick()
    {
        if (_controller.GetState() == SceneController.PlayerState.Dog)
        {
            _controller.items[0] = true;
            Destroy(magazineObject);
        }
    }

    public bool GetPc1stGimmick()
    {
        return pc1stGimmickCompleted;
    }
}
