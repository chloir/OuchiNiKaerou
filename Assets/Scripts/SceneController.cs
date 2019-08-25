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
        Dog = 0,
        Cat = 1,
        Cockloach = 2
    }
    
    private static readonly int WIDTH = 1920;
    private static readonly int HEIGHT = 1080;
    [SerializeField] private GameObject bgImageParent = null;
    [SerializeField] private PlayerState stateOnStart = PlayerState.Dog;
    [SerializeField] private int minWidth = -5760;
    [SerializeField] private int maxWidth = 0;
    [SerializeField] private Image characterImage = null;
    [SerializeField] private Sprite[] characterSprites = new Sprite[3];
    private PlayerState _state = PlayerState.Cat;
    private int bgPosition = 0;
    private Image[] bgImages = null;
    public bool[] items = new bool[6];

    void Start()
    {
        var bgPos = new Vector2(bgPosition, 0);
        
        _state = stateOnStart;
        characterImage.sprite = characterSprites[(int) _state];
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
        
    }

    public void CharacterIconOnClick()
    {
        _state++;
        if ((int)_state > 2)
        {
            _state = PlayerState.Dog;
        }
        
        characterImage.sprite = characterSprites[(int) _state];
        Debug.Log(_state);
    }

    public PlayerState GetState()
    {
        return _state;
    }
}
