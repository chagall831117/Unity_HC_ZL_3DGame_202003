using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// 怪物的血量
    /// </summary>
    public float Hp = 100;
    public int Attack { get; set; }
    public float def
    {
        get
        {
            return 77.5f;
        }
    }
    public int lv = 5;
    public int mp
    {
        get
        {
            return lv * 8;
        }
    }
    private float _damege;
    public float damege
    {
        set
        {
            _damege = Mathf.Clamp(value - def, 1, 9999);
        }
        get
        {
            return _damege;
        }
    }
}
