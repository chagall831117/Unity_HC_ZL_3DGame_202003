using UnityEngine;

public class LearnMemberStatic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(Random.value);
        Time.timeScale = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        print(Random.Range(1,5100));
    }
}
