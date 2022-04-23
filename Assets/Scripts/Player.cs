using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SIDE { Left, Mid, Right }

public class Player : MonoBehaviour
{
    private float xPos;
    private float yPos;

    private float xPosTo;

    private float slideCounter;

    private bool isGrounded;

    private SIDE side;

    private Rigidbody rb;

    private void Start()
    {
        isGrounded = true;

        side = SIDE.Mid;

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ChangePosX();
        Jump();
        Slide();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(xPos - xPosTo) < 0.1f)
        {
            rb.position = new Vector3(xPosTo, rb.position.y, rb.position.z);
            rb.MovePosition(rb.position + new Vector3(0f, 0f, 5f) * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + new Vector3((xPosTo - xPos) * 10f, 0f, 5f) * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    // 캐릭터 좌우이동
    private void ChangePosX()
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

    // 캐릭터 점프
    private void Jump()
    {
        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void Slide()
    {
        slideCounter -= Time.deltaTime;

        if (isGrounded && slideCounter <= 0f && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            slideCounter = 0.5f;
        }
    }
}