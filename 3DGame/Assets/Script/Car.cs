using UnityEngine;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Drive(float value,string sound = "咻咻咻")
    {
        print("開車車 時速為"+value);
        print("開車車音效" + sound);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
