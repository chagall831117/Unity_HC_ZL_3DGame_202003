using UnityEngine;

public class CarManager : MonoBehaviour
{
    public Car car;
    // Start is called before the first frame update
    void Start()
    {
        car.Drive(150);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
