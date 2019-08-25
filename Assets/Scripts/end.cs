using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class end : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        //Debug.Log("押された!");  // ログを出力
        SceneManager.LoadScene("TitleScene");
    }
}
