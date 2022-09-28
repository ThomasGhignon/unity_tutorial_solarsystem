using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{

    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = this.speed;
        float dt = Time.deltaTime;
        angle *= dt;

        if (GameController.Instance)
            angle = angle * GameController.Instance.speed;

        this.transform.Rotate(Vector3.up, angle, Space.Self);
    }
}
