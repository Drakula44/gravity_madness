using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed=5f;
    public float relative_position = 0;
    // public bool
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool rightInput;
        bool leftInput;

        /*rightInput = Input.GetKey(KeyCode.RightArrow);
        leftInput = Input.GetKey(KeyCode.LeftArrow);*/


        
        if (Input.touches.Length != 0)
        {
            Touch touch = Input.GetTouch(0);
            rightInput = touch.position.x > Screen.width / 2;
            leftInput = touch.position.x < Screen.width / 2;
        }
        else
        {
            rightInput = false;
            leftInput = false;
        }

        float direction = (rightInput ? 1f : 0f) - (leftInput ? 1f : 0f);

        if (rightInput)
        {
            relative_position += 1F;
        }
        if (leftInput)
        {
            relative_position -= 1F;
        }
        if(relative_position >= 800)
        {
            relative_position -= 800;
        }
        if(relative_position < 0)
        {
            relative_position += 800;
        }
        Vector2 pos = Conture.Evaulate(relative_position);
        transform.position = pos;
        // Debug.Log(pos);
    }

}
