using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnData data;
    public bool Pass;
    private GameManager Gm;
    void Start()
    {
        StartCoroutine(StartSpawn());
        Gm = FindObjectOfType<GameManager>();
    }

    private IEnumerator StartSpawn()
    {
        for (int s = 0; s < data.spawn.Length; s++)
        {
            yield return new WaitForSeconds(data.spawn[s].time);
            print(data.spawn[s].name);
            for (int m = 0; m < data.spawn[s].monsters.Length; m++)
            {
                Vector3 pos = new Vector3(data.spawn[s].monsters[m].X座標, 13, 50);
                Quaternion qua = Quaternion.Euler(0, 180, 0);
                Instantiate(data.spawn[s].monsters[m].monster, pos, qua);
            }
        }
        yield return new WaitForSeconds(2);
        Gm.WinGame();
    }
}
