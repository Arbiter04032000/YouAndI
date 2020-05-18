using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public ItemCore[] items;
    public bool coinLamp;
    public bool coinPainting;
    public bool coinHatch;

    public List<bool> coins;

    private void Awake()
    {
        coins.Add(coinLamp);
        coins.Add(coinPainting);
        coins.Add(coinHatch);
    }
}
