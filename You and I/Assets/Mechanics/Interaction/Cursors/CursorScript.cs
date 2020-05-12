using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;

public class CursorScript : MonoBehaviour
{
    public int controllerNo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(Input.GetAxis("Horizontal" + controllerNo), 0, 0);
        this.gameObject.transform.Translate(0, -(Input.GetAxis("Vertical" + controllerNo)), 0);


    }
}
