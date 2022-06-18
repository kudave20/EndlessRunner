using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverCanvas;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Time.timeScale = 0f;
            var go = Instantiate(gameOverCanvas);
        }
    }
}
