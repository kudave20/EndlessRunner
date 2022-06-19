using System.Collections;
using UnityEngine;

public enum SIDE { Left, Mid, Right }

public class Player : MonoBehaviour
{
    private float xPos;
    private float xPosTo;

    private float slideCounter;

    private bool isGrounded;
    private bool isSliding;

    private bool isBGMPlaying;

    private SIDE side;

    private Rigidbody rb;

    private GameObject cam;

    private void Start()
    {
        isGrounded = true;
        isSliding = false;
        isBGMPlaying = false;

        side = SIDE.Mid;

        rb = GetComponent<Rigidbody>();

        cam = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        ChangePosX();
        Jump();
        Slide();

        if (!isBGMPlaying && isGrounded && !isSliding)
        {
            SoundManager.Instance.PlayBGMSound(1f);
            isBGMPlaying = true;
        }
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

            SoundManager.Instance.StopBGMSound();
            isBGMPlaying = false;
        }
    }

    private void Slide()
    {
        slideCounter -= Time.deltaTime;

        if (isGrounded && slideCounter <= 0f && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            isSliding = true;

            cam.transform.localPosition = new Vector3(0f, 0.5f, 1f);
            cam.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));

            slideCounter = 1.5f;
            StartCoroutine(SlideCoroutine());

            SoundManager.Instance.StopBGMSound();
            SoundManager.Instance.PlaySFXSound("Sliding_on_ground0", 1f);
            isBGMPlaying = false;
        }
    }

    private IEnumerator SlideCoroutine()
    {
        rb.rotation = Quaternion.Euler(-90f, 0f, 0f);
        rb.position = new Vector3(rb.position.x, -0.5f, rb.position.z);

        yield return new WaitForSeconds(1f);

        rb.rotation = Quaternion.identity;
        rb.position = new Vector3(rb.position.x, 0f, rb.position.z);

        isSliding = false;

        cam.transform.localPosition = new Vector3(0f, 0.5f, 0f);
        cam.transform.localRotation = Quaternion.identity;
    }
}