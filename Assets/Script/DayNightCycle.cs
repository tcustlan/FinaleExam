using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayDuration = 10.0f;  // 一天的持续时间（秒）
    public Light sun;                   // 主光源

    private float rotationSpeed;
    private float initialIntensity;     // 初始光照强度

    void Start()
    {
        rotationSpeed = 360.0f / dayDuration;  // 计算每秒旋转的角度
        initialIntensity = sun.intensity;      // 记录初始光照强度
    }

    void Update()
    {
        // 控制主光源的旋转
        float rotationAmount = rotationSpeed * Time.deltaTime;
        sun.transform.Rotate(Vector3.right, rotationAmount);

        // 限制主光源的旋转在一天之内
        if (sun.transform.eulerAngles.x > 180)
        {
            sun.transform.eulerAngles = new Vector3(180, 0, 0);
        }

        // 如果旋转达到一天的最大值，重新开始
        if (sun.transform.eulerAngles.x <= 0.01f)
        {
            sun.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        // 根据太阳的高度调整光照强度
        AdjustSunIntensity();
    }

    void AdjustSunIntensity()
    {
        // 获取太阳的当前高度（0到180度）
        float sunHeight = sun.transform.eulerAngles.x;

        // 计算光照强度的衰减系数（可以根据需求调整）
        float intensityFactor = Mathf.Clamp01(Mathf.Cos((sunHeight - 90.0f) * Mathf.Deg2Rad));

        // 调整主光源的光照强度
        sun.intensity = initialIntensity * intensityFactor;
    }
}
