using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickSystem : MonoBehaviour
{
    [SerializeField] private SceneController _controller = null;
    [SerializeField] private int pcPassword = 01200218;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PCMystery()
    {
        int playerInput = 0;
        int correctPassword = pcPassword;

        if (playerInput == correctPassword)
        {
            // ギミック成功時処理
        }
    }
}
