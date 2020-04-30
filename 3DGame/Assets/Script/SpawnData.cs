using UnityEngine;

[CreateAssetMenu(fileName = "關卡資料", menuName = "Croac/關卡資料")]
public class SpawnData : ScriptableObject
{
    public SpawnTime[] spawn;
}
//序列化
[System.Serializable]
public class SpawnTime
{
    public string name;
    public float time;
    public SpawnMonster[] monsters;
}
//序列化
[System.Serializable]
public class SpawnMonster
{
    public GameObject monster;
    public float X;
}
