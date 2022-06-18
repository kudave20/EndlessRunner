using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tiles;

    [SerializeField]
    private GameObject player;

    private int cnt;

    private void Start()
    {
        SpawnTile(0);
        cnt = 1;
    }

    private void Update()
    {
        if (player.transform.position.z <= cnt * 50f && player.transform.position.z >= (cnt - 1) * 50f)
        {
            SpawnTile(Random.Range(0, tiles.Length));
            cnt++;
        }
    }

    private void SpawnTile(int idx)
    {
        Instantiate(tiles[idx], new Vector3(0f, 0f, cnt * 50f), Quaternion.identity);
    }
}
