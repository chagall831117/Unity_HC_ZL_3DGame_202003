using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoll : MonoBehaviour
{
    public Transform dragon;
    [Header("追蹤速度")]
    public float Speed = 50;
    public void track()
    {
        Vector3 draPos = dragon.position;
        draPos.y = 50;
        draPos.z -= 10;
        transform.position = Vector3.Lerp(transform.position, draPos, 0.3f * Time.deltaTime *Speed);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        track();
    }
}
