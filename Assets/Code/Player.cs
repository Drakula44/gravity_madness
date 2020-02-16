using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3();
        float dp = 0.1F;
        if(Input.GetKey("w"))
        {
            direction.y = dp;
        }
        if(Input.GetKey("s"))
        {
            direction.y = -dp;
        }
        if(Input.GetKey("a"))
        {
            direction.x = -dp;
        }
        if(Input.GetKey("d"))
        {
            direction.x = dp;
        }
        transform.Translate(direction,Space.World);
    }
}
