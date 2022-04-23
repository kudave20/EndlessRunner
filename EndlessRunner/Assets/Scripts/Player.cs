using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SIDE { Left, Mid, Right }

public class Player : MonoBehaviour
{
    private float xPos;
    private float yPos;

    private float xPosTo;

    private SIDE side;

    private Rigidbody rb;

    private void Start()
    {
        side = SIDE.Mid;

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (side == SIDE.Mid)
            {
                side = SIDE.Left;
                xPosTo = -2f;
            }
            if (side == SIDE.Right)
            {
                side = SIDE.Mid;
                xPosTo = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (side == SIDE.Mid)
            {
                side = SIDE.Right;
                xPosTo = 2f;
            }
            if (side == SIDE.Left)
            {
                side = SIDE.Mid;
                xPosTo = 0f;
            }
        }

        xPos = Mathf.Lerp(xPos, xPosTo, Time.deltaTime * 10f);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(xPos - xPosTo) < 0.1f)
        {
            rb.position = new Vector3(xPosTo, rb.position.y, rb.position.z);
            rb.MovePosition(rb.position + new Vector3(0f, yPos, 5f) * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + new Vector3((xPosTo - xPos) * 10f, yPos, 5f) * Time.fixedDeltaTime);
        }
    }
}