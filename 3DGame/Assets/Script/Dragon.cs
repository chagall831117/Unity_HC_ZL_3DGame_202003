using UnityEngine;
using System.Collections;

public class Dragon : MonoBehaviour
{
    [Header("阿就虛擬搖桿 還想怎樣")]
    public Joystick Joy;
    [Header("阿就移動速度 還想怎樣"),Range(1,1000)]
    public float speed = 30;
    [Header("啊就火球 不然呢")]
    public GameObject FireBall;
    [Header("啊就冷卻時間 不然呢")]
    public float Cd = 1;
    private Animator Ani;
    private float Timer;
    public float DelayFire = 0.2f;
    public float FireBallSpeed = 500;
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
    }
}
