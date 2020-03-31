using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy Enemy1, Enemy2;
    // Start is called before the first frame update
    void Start()
    {
        Enemy1.Hp = 6000;
        print(Enemy2.Hp);
        Enemy1.Attack = 60000;
        print("敵人1的攻擊力"+Enemy1.Attack);
    }
    /// <summary>
    /// 攻擊力
    /// </summary>

    // Update is called once per frame
    void Update()
    {
        
    }
}
