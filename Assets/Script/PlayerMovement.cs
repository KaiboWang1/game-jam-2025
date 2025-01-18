using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseUpwardAcceleration = 1.0f; // 基础向上加速度
    public float volume = 1.0f; // 气泡的体积
    public float sprayForceMultiplier = 10.0f; // 喷射力的倍数
    public float volumeConsumptionRate = 0.1f; // 喷射时体积消耗率
    public float constantUpwardSpeed = 1.0f; // 恒定的向上速度
    public float dragFactor = 0.95f; // 阻力因子

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // 应用阻力
        rb.velocity *= dragFactor;
    }

    // Update is called once per frame
    void Update()
    {
        // 恒定向上速度与体积相关
        float sqrtVolume = Mathf.Sqrt(volume);
        rb.velocity = new Vector2(rb.velocity.x, constantUpwardSpeed * sqrtVolume);

        // 检测鼠标输入
        if (Input.GetMouseButton(0))
        {
            Spray();
        }
        
        // 根据体积调整主角大小
        AdjustSize();
    }

    void Spray()
    {
        // 获取鼠标位置并计算喷射方向
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        // 施加喷射力
        rb.AddForce(-direction * sprayForceMultiplier * volume * Time.deltaTime);

        // 消耗体积
        volume -= volumeConsumptionRate * Time.deltaTime;
        if (volume < 0.1f) volume = 0.1f; // 确保体积不会小于某个值
    }

    void AdjustSize()
    {
        // 假设初始体积为1时，localScale为(1, 1, 1)
        transform.localScale = new Vector3(volume, volume, 1);
    }
}
