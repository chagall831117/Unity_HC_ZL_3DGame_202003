using UnityEngine;
[CreateAssetMenu(fileName = "怪物資料", menuName = "Croac/怪物資料")]
public class MonsterData : ScriptableObject
{
    [Header("生命值")]
    public float Hp;
    [Header("攻擊力")]
    public float Atk;
    [Header("速度")]
    public float Speed;

}
