using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnData data;
    void Start()
    {
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        for (int i = 0; i < data.spawn.Length; i++)
        {
            yield return new WaitForSeconds(data.spawn[i].time);
            print(data.spawn[i].name);
        }
    }
}
