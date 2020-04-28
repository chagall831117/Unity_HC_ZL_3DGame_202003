using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;

    /// <summary>
    /// 移動方法
    /// </summary>
    public void MoveMethod()
    {
        transform.Translate(0, 0, -Speed * Time.deltaTime);
    }
    private void Update()
    {
        MoveMethod();
    }
}
