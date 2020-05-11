using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NullText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.gameObject.GetComponentInChildren<Text>().text == "")
        {
            transform.gameObject.GetComponent<Image>().enabled = false;
        }
    }
}
