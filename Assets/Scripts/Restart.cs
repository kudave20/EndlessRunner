using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        SoundManager.Instance.PlayBGMSound(1f);

        SceneManager.LoadScene(0);
    }
}
