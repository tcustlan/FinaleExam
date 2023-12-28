using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    public Transform player;
    public Camera miniMapCamera;
    public RawImage miniMapImage;

    void Update()
    {
        Vector3 playerPosition = player.position;
        UpdateMiniMap(playerPosition);
    }

    void UpdateMiniMap(Vector3 playerPosition)
    {
        // 设置小地图相机的位置
        miniMapCamera.transform.position = new Vector3(playerPosition.x, miniMapCamera.transform.position.y, playerPosition.z);

        // 渲染小地图
        RenderTexture miniMapRenderTexture = new RenderTexture(256, 256, 0);
        miniMapCamera.targetTexture = miniMapRenderTexture;
        miniMapCamera.Render();

        // 将渲染结果显示在RawImage上
        miniMapImage.texture = miniMapRenderTexture;
    }
}

