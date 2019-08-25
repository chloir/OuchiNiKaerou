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
    [SerializeField] private GameObject goki = null;
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

    public int GetBgPos() { return bgPosition; }

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
        
        GokiRandom();
        
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
        
        GokiRandom();
        
        Debug.Log(bgPosition);
    }

    public void GokiRandom()
    {
        int c = 0;
        if (c == 0)
        {
            var obj = Instantiate(goki); 
            obj.transform.position = new Vector3(bgPosition + 1050, -146);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0), ForceMode2D.Impulse);
            Debug.Log("Goki");
        }
    }

    public void Dog()
    {
        _state = PlayerState.Dog;
        characterImage.sprite = characterSprites[(int) _state];
    }

    public void Cat()
    {
        _state = PlayerState.Cat;
        characterImage.sprite = characterSprites[(int) _state];
    }

    public void Loach()
    {
        _state = PlayerState.Cockloach;
        characterImage.sprite = characterSprites[(int) _state];
    }

    public void CharacterIconOnClick()
    {
        _state++;
        if ((int)_state > 2)
        {
            _state = PlayerState.Dog;
        }
        

        Debug.Log(_state);
    }

    public PlayerState GetState()
    {
        return _state;
    }
}
