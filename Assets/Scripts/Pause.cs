using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1f;

        GameManager.Instance.isPauseCanvasOn = false;

        SoundManager.Instance.PlayBGMSound(1f);

        Destroy(transform.parent.gameObject);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
