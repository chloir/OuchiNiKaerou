using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    [SerializeField] private GameObject gImage = null;
    
    private void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => ObservableGAnimator());
    }

    private void ObservableGAnimator()
    {
        Observable.FromCoroutine(GAnimator)
            .Subscribe(_ => SceneManager.LoadScene("SampleScene"));
    }

    public GameObject GetImageInstance() { return gImage; }

    IEnumerator GAnimator()
    {
        var img = GetImageInstance();
        while(img.transform.position.x < 300)
        {
            img.transform.Translate(10, 10, 0);
            yield return null;
        }
    }
}
