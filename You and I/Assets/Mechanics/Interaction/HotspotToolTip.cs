using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotspotToolTip : MonoBehaviour
{
    public Text hotspotTT;

    public void ShowTT()
    {
        hotspotTT.text = gameObject.name;
    }

    public void HideTT()
    {
        hotspotTT.text = "";
    }
}
