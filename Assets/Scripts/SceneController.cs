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
    private PlayerState _state = PlayerState.Cat;
    private int bgPosition01 = 0;
    private int bgPosition02 = 1920;
    private int bgPosition03 = 3240;
    private int bgPosition04 = 5760;
    private Image[] bgImages = null;

    void Start()
    {
        _state = stateOnStart;
        bgImages = bgImageParent.GetComponentsInChildren<Image>();
        
    }

    public void LeftOnClick()
    {
        // 左ボタン押下時の動作
        
    }

    public void RightOnClick()
    {
        // 右ボタン押下時の動作
        
    }

    public PlayerState GetState()
    {
        return _state;
    }

    IEnumerator BgScroller(int start, int end)
    {
        
    }
    
    void Update()
    {
        
    }
}
