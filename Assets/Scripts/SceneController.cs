using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public enum PlayerState
    {
        Dog,
        Cat,
        Alien,
        Cockloach
    }
    
    private static readonly int WIDTH = 1920;
    private static readonly int HEIGHT = 1080;
    [SerializeField] private GameObject bgImageParent = null;
    [SerializeField] private PlayerState stateOnStart = PlayerState.Cat;
    [SerializeField] private int minWidth = -5760;
    [SerializeField] private int maxWidth = 0;
    private PlayerState _state = PlayerState.Cat;
    private int bgPosition = 0;
    private Image[] bgImages = null;
    public bool[] items;

    void Start()
    {
        var bgPos = new Vector2(bgPosition, 0);
        
        _state = stateOnStart;
        bgImageParent.transform.position = bgPos;
    }

    public void LeftOnClick()
    {
        // 左ボタン押下時の動作
        bgPosition += WIDTH;
        if (bgPosition > maxWidth)
        {
            bgPosition = minWidth;
        }
        var vec = new Vector2(bgPosition, 0);
        bgImageParent.transform.localPosition = vec;
        
        Debug.Log(bgPosition);
    }

    public void RightOnClick()
    {
        // 右ボタン押下時の動作
        bgPosition -= WIDTH;
        if (bgPosition < minWidth)
        {
            bgPosition = maxWidth;
        }
        var vec = new Vector2(bgPosition, 0);
        bgImageParent.transform.localPosition = vec;
        
        Debug.Log(bgPosition);
    }

    public PlayerState GetState()
    {
        return _state;
    }

    IEnumerator BgScroller(int start, int end)
    {
        yield break;
    }
    
    void Update()
    {
        
    }
}
