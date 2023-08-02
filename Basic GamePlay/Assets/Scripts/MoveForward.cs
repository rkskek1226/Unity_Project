using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //충돌 있을 시에는 Rigidbody 추천
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
