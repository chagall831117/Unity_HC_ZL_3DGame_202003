using UnityEngine;

public class Ball : MonoBehaviour
{
    public string Type;
    public float Damage = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "敵人" && Type == "玩家")
        {
            other.GetComponent<Monster>().Hurt(Damage);
            Destroy(gameObject);
        }
        if (other.name == "飛龍" && Type == "敵人")
        {
            other.GetComponent<Dragon>().Hurt(Damage);
            Destroy(gameObject);
        }
    }
}
