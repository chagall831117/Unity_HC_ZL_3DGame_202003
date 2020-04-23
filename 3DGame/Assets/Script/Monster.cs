using System.Collections;using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;
    public Animator Ani;
    public float Hp;
    // Start is called before the first frame update
    void Start()
    {
        Ani = GetComponent<Animator>();
        Hp = monsterData.Hp;
    }
    /// <summary>
    /// 受傷方法
    /// </summary>
    /// <param name="Attack"></param>
    public void Hurt(float Attack)
    {
        Hp -= Attack;
        print("生命值:"+Hp);
        if (Hp <= 0) Dead();
    }
    public void Dead()
    {
        Ani.SetBool("死亡開關",true);
    }
}
