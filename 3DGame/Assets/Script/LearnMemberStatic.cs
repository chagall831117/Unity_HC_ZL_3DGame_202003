﻿using UnityEngine;

public class LearnMemberStatic : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        print(Random.value);
        Time.timeScale = 0.1f;
        print(Mathf.PI);
        print(Mathf.Abs(-5156151561f));
    }

    // Update is called once per frame
    void Update()
    {
        print(Random.Range(1,5100));
        print("攝影機數量" + Camera.allCamerasCount);
        print(cam.depth);
    }
}
