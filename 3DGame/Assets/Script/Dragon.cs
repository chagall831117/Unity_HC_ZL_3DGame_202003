using UnityEngine;

public class Dragon : MonoBehaviour
{
    public Joystick Joy;
    [Header("移動速度"),Range(1,1000)]
    public float speed = 30;
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
        transform.position = pos;
    }
    private void Update()
    {
        Move();
    }
}
