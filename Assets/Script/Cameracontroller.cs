using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 玩家的Transform，你需要将玩家的Transform赋值给这个变量
    public Transform player;

    // 鼠标灵敏度
    public float mouseSensitivity;

    // X轴旋转角度
    private float mouseX, mouseY;
    private float xRotation;
    private bool cameraswitch;
    // 相机与玩家之间的偏移值

    private void Start()
    {
        cameraswitch = false;
        // 设置相机的初始位置为玩家的 x 座标 + 偏移值
        transform.position = new Vector3(player.position.x, player.position.y + 5, player.position.z + 1);
    }

    private void Update()
    {
        // 获取鼠标在X和Y轴上的移动量
        mouseX = Input.GetAxis("Mouse X") * 2 * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * 2 * mouseSensitivity * Time.deltaTime;

        // 计算X轴的旋转角度
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 限制视角在-90到90度之间

        // 根据鼠标水平移动旋转玩家
        player.Rotate(Vector3.up * mouseX);

        // 设置摄像机的本地旋转，以实现垂直视角旋转
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // 更新相机的位置，根据cameraswitch的值设置在玩家前方或后方
        if (cameraswitch == false)
        {
            transform.position = new Vector3(player.position.x, player.position.y + 2, player.position.z + 2);
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y + 5, player.position.z - 5);
        }

        // 切换相机位置的按键检测
        if (Input.GetKeyDown(KeyCode.F5))
        {
            cameraswitch = !cameraswitch; // 切换相机位置状态
        }
    }
}
