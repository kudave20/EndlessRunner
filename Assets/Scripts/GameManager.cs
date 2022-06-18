using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameObject pauseCanvas;

    public bool isPauseCanvasOn;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPauseCanvasOn)
        {
            isPauseCanvasOn = true;
            Time.timeScale = 0f;
            Instantiate(pauseCanvas);
        }
    }

    public void OnDestroy()
    {
        Instance = null;
    }
}
