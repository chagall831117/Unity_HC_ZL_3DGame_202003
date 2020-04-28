using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dragon : MonoBehaviour
{
    [Header("虛擬搖桿")]
    public Joystick Joy;
    [Header("移動速度"),Range(1,1000)]
    public float speed = 30;
    [Header("火球")]
    public GameObject FireBall;
    [Header("冷卻時間")]
    public float Cd = 1;
    [Header("血量")]
    public float Hp = 1;
    private Animator Ani;//動畫
    private float Timer;//計時器
    public float DelayFire = 0.2f;//火球延遲
    public float FireBallSpeed = 500;
    public Image HpBar;
    public float HpRatio;
    public float HpBefore;
    /// <summary>
    /// 移動方法
    /// </summary>
    public void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        transform.Translate(speed * Time.deltaTime * h, 0, speed * Time.deltaTime * v);
        float JoyV = Joy.Vertical;
        float JoyH = Joy.Horizontal;
        transform.Translate(speed * Time.deltaTime * JoyH, 0, speed * Time.deltaTime * JoyV);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, 30, 70);
        pos.z = Mathf.Clamp(pos.z, 20, 30);
        transform.position = pos;
    }
    private void Start()
    {
        Ani = GetComponent<Animator>();
    }
    /// <summary>
    /// 攻擊動畫跟速度
    /// </summary>
    public void Attack()
    {
        Timer += Time.deltaTime;
        if (Timer >= Cd)
        {
            Ani.SetTrigger("攻擊觸發");
            Timer = 0;
            StartCoroutine(DelayFireBall());
        }
    }
    /// <summary>
    /// 產生火球
    /// </summary>
    /// <returns></returns>
    public IEnumerator DelayFireBall()
    {
        yield return new WaitForSeconds(DelayFire);
        Vector3 PosFire = transform.position;
        PosFire.z += 8;
        GameObject Temp = Instantiate(FireBall, PosFire, Quaternion.identity);
        Temp.GetComponent<Rigidbody>().AddForce(0, 0, FireBallSpeed);

    }
    private void Update()
    {
        Move();
        Attack();
        HpSystem();
    }
    /// <summary>
    /// 血條系統
    /// </summary>
    public void HpSystem()
    {
        HpRatio = Hp / 100 ;
        HpBar.fillAmount = Mathf.Lerp(HpBefore,HpRatio,0.1f);
        HpBefore = Mathf.Lerp(HpBefore, HpRatio, 0.1f);
    }
    /// <summary>
    /// 加速藥水加速
    /// </summary>
    public void EatPotionSpeed()
    {
        Cd = Mathf.Clamp(Cd - 0.25f, 0.25f, 2);
    }
    /// <summary>
    /// 生命藥水補血
    /// </summary>
    public void EatPotionHealth()
    {
        HpBefore = Hp/100;
        Hp = Mathf.Clamp(Hp + 25, 0, 100);
    }
    /// <summary>
    /// 碰撞器
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "加速藥水")
        {
            EatPotionSpeed();
        }
        if (other.tag == "生命藥水")
        {
            EatPotionHealth();
        }
    }
}
