using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class BgController : MonoBehaviour
{
    [SerializeField] private SceneController _controller = null;
    [SerializeField] private GameObject dogBg = null;
    [SerializeField] private GameObject catBg = null;
    [SerializeField] private GameObject gokiBg = null;
    
    void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                switch (_controller.GetState())
                {
                    case SceneController.PlayerState.Dog:
                        dogBg.transform.Translate(Vector3.zero);
                        break;
                    case SceneController.PlayerState.Cat:

                        break;
                    case SceneController.PlayerState.Cockloach:
                        
                        break;
                }
            });
    }
}
