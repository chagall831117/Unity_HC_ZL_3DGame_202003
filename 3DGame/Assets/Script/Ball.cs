using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Damage = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "怪物")
        {
            other.GetComponent<Monster>().Hurt(Damage);
        }
    }
}
