using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class BgController : MonoBehaviour
{
    private static readonly int WIDTH = 1920;
    private static readonly int HEIGHT = 1080;
    [SerializeField] private SceneController _controller = null;
    [SerializeField] private GameObject dogBg = null;
    [SerializeField] private GameObject catBg = null;
    [SerializeField] private GameObject gokiBg = null;
    [SerializeField] private GameObject bgImg = null;
    private int x = 0, y = 0;

    void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                switch (_controller.GetState())
                {
                    case SceneController.PlayerState.Dog:
                        x = _controller.GetBgPos();
                        bgImg.transform.localPosition = new Vector3(x, 0);
                        break;
                    case SceneController.PlayerState.Cat:
                        x = _controller.GetBgPos();
                        bgImg.transform.localPosition = new Vector3(x, 1080);
                        break;
                    case SceneController.PlayerState.Cockloach:
                        x = _controller.GetBgPos();
                        bgImg.transform.localPosition = new Vector3(x, 2160);
                        break;
                }
            });
    }

    IEnumerator BgScroller(int start, int dest)
    {
        if (start < dest)
        {
            start += 10;
        }

        if (start > dest)
        {
            start -= 10;
        }

        yield return null;
    }
}
