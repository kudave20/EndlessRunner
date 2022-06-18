using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    [SerializeField]
    private Text coinText;

    private void Update()
    {
        coinText.text = GameManager.Instance.coin.ToString();
    }
}
