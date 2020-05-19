using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    
    public string name;
    public bool itemLine;
    public int itemID;

    [TextArea(3, 10)]
    public string[] sentences;
    public Response[] responses;
    
}
