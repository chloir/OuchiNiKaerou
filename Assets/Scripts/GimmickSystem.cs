using System;
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
    [SerializeField] private GameObject loginScr = null;
    [SerializeField] private GameObject desktop = null;
    [SerializeField] private GameObject magazineObject = null;
    [SerializeField] private Messages dogMasterData = null;
    [SerializeField] private Messages catMasterData = null;
    [SerializeField] private Messages gokiMasterData = null;
    private bool pcIsOn = false;
    private bool pc1stGimmickCompleted = false;

    private void Start()
    {
        loginScr.SetActive(false);
        desktop.SetActive(false);
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
            loginScr.SetActive(true);
        }
    }

    public void PCInputOnComplete()
    {
        string playerInput = loginScr.GetComponentInChildren<InputField>().text;
        string correctPassword = pcPassword.ToString();
        
        if (_controller.GetState() == SceneController.PlayerState.Cat)
        {
            if (playerInput == correctPassword)
            {
                desktop.SetActive(true);
            }
            else
            {
                loginScr.GetComponentInChildren<InputField>().text = "違う";
            }
        }
    }

    public void ReturnFromPc()
    {
        loginScr.SetActive(false);
    }

    public void BelowBed()
    {
        if (_controller.GetState() == SceneController.PlayerState.Cat)
        {
            _controller.items[1] = true;
        }
    }

    public void BedOnClick()
    {
        switch (_controller.GetState())
        {
            case SceneController.PlayerState.Dog:
                window.ChangeMessage(dogMasterData.messageTexts[5]);
                break;
            case SceneController.PlayerState.Cat:
                window.ChangeMessage(catMasterData.messageTexts[5]);
                break;
            case SceneController.PlayerState.Cockloach:
                window.ChangeMessage(gokiMasterData.messageTexts[5]);
                break;
        }
    }

    public void SideTableOnClick()
    {
        switch (_controller.GetState())
        {
            case SceneController.PlayerState.Dog:
                if (pc1stGimmickCompleted)
                {
                    DogSideTableGimmick();
                }
                break;
            case SceneController.PlayerState.Cat:
                window.ChangeMessage(catMasterData.messageTexts[3]);
                break;
            case SceneController.PlayerState.Cockloach:
                window.ChangeMessage(gokiMasterData.messageTexts[3]);
                break;
        }
    }

    private void DogSideTableGimmick()
    {
        
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
        switch (_controller.GetState())
        {
            case SceneController.PlayerState.Dog:
                break;
            case SceneController.PlayerState.Cat:
                break;
            case SceneController.PlayerState.Cockloach:
                break;
        }
    }

    public void MagazineGimmick()
    {
        switch (_controller.GetState())
        {
            case SceneController.PlayerState.Dog:
                break;
            case SceneController.PlayerState.Cat:
                break;
            case SceneController.PlayerState.Cockloach:
                break;
        }
    }

    public bool GetPc1stGimmick()
    {
        return pc1stGimmickCompleted;
    }
}
