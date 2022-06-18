using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameObject pauseCanvas;

    public bool isPauseCanvasOn;

    public int coin;

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
            Time.timeScale = 0f;

            isPauseCanvasOn = true;

            SoundManager.Instance.StopBGMSound();

            Instantiate(pauseCanvas);
        }
    }

    public void OnDestroy()
    {
        Instance = null;
    }
}
