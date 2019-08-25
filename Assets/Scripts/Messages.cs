using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Messages : ScriptableObject
{
    [TextArea(3, 5)]
    public List<string> messageTexts = new List<string>();
}
