using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GimmickSystem : MonoBehaviour
{
    [SerializeField] private SceneController _controller = null;
    [SerializeField] private MessageWindow window = null;
    [SerializeField] private string pcPassword = "01200218";
    [SerializeField] private string pcPassword2 = "skylight";
    [SerializeField] private GameObject loginScr = null;
    [SerializeField] private GameObject loginScr2 = null;
    [SerializeField] private GameObject desktop = null;
    [SerializeField] private GameObject connectScr = null;
    [SerializeField] private GameObject paperScr = null;
    [SerializeField] private GameObject magazineObject = null;
    [SerializeField] private Messages dogMasterData = null;
    [SerializeField] private Messages catMasterData = null;
    [SerializeField] private Messages gokiMasterData = null;
    [SerializeField] private GameObject belowTvView = null;
    private bool pcIsOn = false;
    private bool pc1stGimmickCompleted = false;
    private bool pc2ndGimmickCompleted = false;

    private void Start()
    {
        loginScr.SetActive(false);
        loginScr2.SetActive(false);
        desktop.SetActive(false);
        belowTvView.SetActive(false);
        connectScr.SetActive(false);
        paperScr.SetActive(false);
    }

    public void PCPowerOn()
    {
        if (!pcIsOn && _controller.GetState() == SceneController.PlayerState.Dog)
        {
            pcIsOn = true;
            window.PcOnMessage();
        }

        if (pcIsOn && _controller.GetState() == SceneController.PlayerState.Dog)
        {
            window.ChangeMessage(dogMasterData.messageTexts[3]);
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
                Destroy(loginScr);
                connectScr.SetActive(true);
            }
            else
            {
                loginScr.GetComponentInChildren<InputField>().text = "違う";
            }
        }
    }

    public void LoginEneter()
    {
        if (_controller.GetState() == SceneController.PlayerState.Cat)
        {
            Destroy(connectScr);
            loginScr2.SetActive(true);

        }
    }


    public void ConnectScrScript()
    {
        Destroy(connectScr);
        desktop.SetActive(true);
    }

    public void PcSecondGimmick()
    {
        string playerInput = desktop.GetComponentInChildren<InputField>().text;
        string correctPassword = pcPassword2;
        

        if (pc1stGimmickCompleted)
        {
            if (_controller.GetState() == SceneController.PlayerState.Cat)
            {
                if (playerInput == correctPassword)
                {
                    Destroy(desktop);
                    SceneManager.LoadScene("End");
                }
            }
        }
    }

    public void ReturnFromPc()
    {
        loginScr.SetActive(false);
        desktop.SetActive(false);
        connectScr.SetActive(false);
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
                window.ChangeMessage(dogMasterData.messageTexts[9]);
                break;
            case SceneController.PlayerState.Cat:
                window.ChangeMessage(catMasterData.messageTexts[6]);
                break;
            case SceneController.PlayerState.Cockloach:
                window.ChangeMessage(gokiMasterData.messageTexts[9]);
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
                // window.ChangeMessage(gokiMasterData.messageTexts[3]);
                break;
        }
    }

    private void DogSideTableGimmick()
    {
        window.ChangeMessage(dogMasterData.messageTexts[7]);
    }

    public void BelowTV()
    {
        if (_controller.GetState() == SceneController.PlayerState.Cockloach)
        {
            belowTvView.SetActive(true);
        }
    }

    public void ExitBelowTv()
    {
        belowTvView.SetActive(false);
    }

    public void PosterGimmick()
    {
        switch (_controller.GetState())
        {
            case SceneController.PlayerState.Dog:
                window.ChangeMessage(dogMasterData.messageTexts[4]);
                break;
            case SceneController.PlayerState.Cat:
                window.ChangeMessage(catMasterData.messageTexts[4]);
                paperScr.SetActive(true);
                break;
            case SceneController.PlayerState.Cockloach:
                break;
        }
    }

    public void close()
    {
        paperScr.SetActive(false);
    }

    public void MagazineGimmick()
    {
        switch (_controller.GetState())
        {
            case SceneController.PlayerState.Dog:
                window.ChangeMessage(dogMasterData.messageTexts[0]);
                break;
            case SceneController.PlayerState.Cat:
                window.ChangeMessage(catMasterData.messageTexts[11]);
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
