using UnityEngine;

public class Ball : MonoBehaviour
{
    public string Type;
    public float Damage = 25;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "敵人" && Type == "玩家")
        {
            other.GetComponent<Monster>().Hurt(100);
            Destroy(gameObject);
        }
        if (other.name == "飛龍" && Type == "敵人")
        {
            other.GetComponent<Dragon>().Hurt(25);
            Destroy(gameObject);
        }
    }
}
