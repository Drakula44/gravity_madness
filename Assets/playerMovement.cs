using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed=5f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*bool rightInput = Input.GetKey(KeyCode.RightArrow);
        bool leftInput = Input.GetKey(KeyCode.LeftArrow);*/

        Touch touch = Input.GetTouch(0);
        bool rightInput = touch.position.x < Screen.width / 2;
        bool leftInput = touch.position.x > Screen.width / 2;

        float direction = (rightInput ? 1f : 0f) - (leftInput ? 1f : 0f);

        rb.velocity = direction * transform.right * speed * Time.fixedDeltaTime;
        if (rightInput)
        {
            RaycastHit2D wallDetectRight = Physics2D.Raycast(transform.position, transform.right, 1f);

            if (wallDetectRight && wallDetectRight.collider.gameObject.name == "Environment")
            {
                transform.Rotate(new Vector3(0, 0, 90), Space.Self);
            }
        }
        if (leftInput)
        {
            RaycastHit2D wallDetectLeft = Physics2D.Raycast(transform.position, -transform.right, 1f);

            if (wallDetectLeft && wallDetectLeft.collider.gameObject.name == "Environment")
            {
                transform.Rotate(new Vector3(0, 0, -90), Space.Self);
            }
        }

    }
}
