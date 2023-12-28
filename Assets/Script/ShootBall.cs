using UnityEngine;
using System.Collections;

public class ShootBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform shootPoint;
    public float initialSpeed = 10f;
    public float gravity = 2f;
    public KeyCode shootKey = KeyCode.Q;
    public float shootInterval = 0.5f; // 发射间隔时间
    public float despawnTime = 3f; // 子弹消失时间

    private bool isShooting = false;

    void Update()
    {
        if (Input.GetKeyDown(shootKey) && !isShooting)
        {
            isShooting = true;
            StartCoroutine(ShootCoroutine());
        }
        else if (Input.GetKeyUp(shootKey))
        {
            isShooting = false;
        }
    }

    IEnumerator ShootCoroutine()
    {
        while (isShooting)
        {
            Shoot();
            yield return new WaitForSeconds(shootInterval);
        }
    }

    void Shoot()
    {
        GameObject ball = Instantiate(ballPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            ballRb.velocity = shootPoint.forward * initialSpeed;
            ballRb.velocity += Vector3.down * gravity * Time.deltaTime;

            // 設定子彈消失時間
            StartCoroutine(Despawn(ball));
        }
    }

    IEnumerator Despawn(GameObject ball)
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(ball);
    }
}
