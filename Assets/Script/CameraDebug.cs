using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDebug : MonoBehaviour
{
    private Camera camera1;

    void Start()
    {
        // 通過名稱找到相機
        camera1 = GameObject.Find("Camera1").GetComponent<Camera>();

        if (camera1 == null)
        {
            Debug.LogError("Camera1 not found!");
        }
    }

    void Update()
    {
        if (camera1 != null)
        {
            // 獲取相機的位置
            Vector3 cameraPosition = camera1.transform.position;

            // 在控制台上顯示相機的位置信息
            Debug.Log($"Camera1 Position: {cameraPosition}");

            // 如果你想在場景中顯示相機位置，可以使用GUI、TextMesh或UI Text等方式在畫面上顯示信息
        }
    }
}

