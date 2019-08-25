using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class BgController : MonoBehaviour
{
    [SerializeField] private SceneController _controller = null;
    [SerializeField] private GameObject[] bgs = null;
    [SerializeField] private Sprite[] bgSprites = null;
    
    void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                switch (_controller.GetState())
                {
                    case SceneController.PlayerState.Dog:
                        for (int i = 0; i < bgs.Length; i++)
                        {
                            var bg = bgs[i];
                            bg.GetComponent<Image>().sprite = bgSprites[i];
                        }
                        break;
                    case SceneController.PlayerState.Cat:
                        for (int i = 0; i < bgs.Length; i++)
                        {
                            var bg = bgs[i];
                            bg.GetComponent<Image>().sprite = bgSprites[i + 4];
                        }
                        break;
                    case SceneController.PlayerState.Cockloach:
                        for (int i = 0; i < bgs.Length; i++)
                        {
                            var bg = bgs[i];
                            bg.GetComponent<Image>().sprite = bgSprites[i + 8];
                        }
                        break;
                }
            });
    }
}
