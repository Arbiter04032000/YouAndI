using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCamScript : MonoBehaviour
{
    //Remember to set main canvas to Render Mode > Screen Space - Camera to get this to work!

    public RenderTexture tex;
    private void Awake()
    {
        tex = this.GetComponent<Camera>().targetTexture;
    }
}
