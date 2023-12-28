using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float gravity = 2f; // 逐渐增加的重力

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // 设置初始速度
            rb.velocity = transform.forward * initialSpeed;
        }
        else
        {
            Debug.LogError("Rigidbody component not found on bullet!");
        }
    }

    void Update()
    {
        // 逐渐增加重力
        if (rb != null)
        {
            rb.velocity += Vector3.down * gravity * Time.deltaTime;
        }
    }

    // 其他子弹逻辑...
}
