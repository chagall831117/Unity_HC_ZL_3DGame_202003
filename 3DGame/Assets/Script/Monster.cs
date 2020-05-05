using System.Collections;using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;
    public GameObject DropHealth;//生命藥水掉落
    public GameObject DropSpeed;//加速藥水掉落
    public Animator Ani;
    public GameObject Bullet;//子彈
    private float Hp;
    private float Timer;//計時器
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
        GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
        Invoke("ResetColor", 0.1f);
        if (Hp <= 0) Dead();
    }
    private void ResetColor()
    {
        GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.white;
    }
    /// <summary>
    /// 死亡方法
    /// </summary>
    public void Dead()
    {
        Ani.SetBool("死亡開關",true);
        DropPotion();
        Destroy(gameObject, 0.2f);
    }
    /// <summary>
    /// 掉落藥水
    /// </summary>
    public void DropPotion()
    {
        float RanNumber = Random.Range(0,1f);
        float RanNumber2 = Random.Range(0,1f);
        print(RanNumber);
        print(RanNumber2);
        if (RanNumber <= monsterData.DropHealth)
        {
            Instantiate(DropHealth, transform.position + transform.right*Random.Range(-2,2), Quaternion.identity);
            print("掉落了生命藥水");
        }
        if (RanNumber2 <= monsterData.DropHealth)
        {
            Instantiate(DropSpeed, transform.position + transform.right * Random.Range(-2, 2), Quaternion.identity);
            print("掉落了加速藥水");
        }
    }
    private void Update()
    {
        Attack();
    }
    public void Attack()
    {
        Timer += Time.deltaTime;
        if (Timer >= monsterData.Cd)
        {
            Timer = 0;
            GameObject Temp = Instantiate(Bullet, transform.position + transform.forward, Quaternion.identity);
            Temp.AddComponent<Move>().Speed = monsterData.BulletSpeed;
            Temp.AddComponent<Ball>().Type = "敵人";
        }
    }
}
