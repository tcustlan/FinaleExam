using UnityEngine;
using UnityEngine.UI;

public class DirectionIndicator : MonoBehaviour
{
    public Transform playerTransform;
    public Text directionText;

    // Update is called once per frame
    void Update()
    {
        // 获取角色朝向向量
        Vector3 facingDirection = playerTransform.forward;

        // 计算角度
        float angle = Mathf.Atan2(facingDirection.z, facingDirection.x) * Mathf.Rad2Deg;

        // 将角度转换为方向文本
        string direction;
        if (angle >= -45f && angle < 45f)
        {
            direction = "東";
        }
        else if (angle >= 45f && angle < 135f)
        {
            direction = "北";
        }
        else if (angle >= -135f && angle < -45f)
        {
            direction = "南";
        }
        else
        {
            direction = "西";
        }

        // 更新UI文本
        directionText.text = "方向:" + direction;
    }
}
