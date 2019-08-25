using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    [SerializeField] private Messages messageMaster = null;
    private Text messageText = null;
    private bool isInit = true;

    void Start()
    {
        messageText = GetComponentInChildren<Text>();

        this.UpdateAsObservable()
            .Where(_ => isInit)
            .Subscribe(_ =>
            {
                isInit = false;
                messageText.text = messageMaster.messageTexts[0];
            });
    }

    public void MessageWindowOnClick()
    {
        messageText.text = null;
    }

    public void PcOnMessage()
    {
        messageText.text = messageMaster.messageTexts[1];
    }
}
