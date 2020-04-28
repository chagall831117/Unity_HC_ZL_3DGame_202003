﻿using UnityEngine;
[CreateAssetMenu(fileName = "怪物資料", menuName = "Croac/怪物資料")]
public class MonsterData : ScriptableObject
{
    [Header("生命值")]
    public float Hp;
    [Header("攻擊力")]
    public float Atk;
    [Header("速度")]
    public float Speed;
    [Header("藥水掉落機率"),Range(0,1)]
    public float DropHealth;
}
