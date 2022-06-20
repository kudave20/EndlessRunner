using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameObject pauseCanvas;

    public bool isGameStarted { get; set; }

    public bool isPauseCanvasOn { get; set; }

    public int coin { get; set; }

    [SerializeField]
    private Text pressToStart;

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

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isGameStarted)
        {
            Time.timeScale = 1f;

            isGameStarted = true;

            Destroy(pressToStart.gameObject);
        }
    }

    public void OnDestroy()
    {
        Instance = null;
    }
}
