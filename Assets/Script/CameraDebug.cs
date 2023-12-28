using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDebug : MonoBehaviour
{
    private Camera camera1;

    void Start()
    {
        // �q�L�W�٧��۾�
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
            // ����۾�����m
            Vector3 cameraPosition = camera1.transform.position;

            // �b����x�W��ܬ۾�����m�H��
            Debug.Log($"Camera1 Position: {cameraPosition}");

            // �p�G�A�Q�b��������ܬ۾���m�A�i�H�ϥ�GUI�BTextMesh��UI Text���覡�b�e���W��ܫH��
        }
    }
}

