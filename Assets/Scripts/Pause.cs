using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance.isPauseCanvasOn = false;
        Destroy(transform.parent.gameObject);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
