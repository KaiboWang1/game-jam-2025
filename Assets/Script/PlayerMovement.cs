using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerMovement类负责处理玩家的移动和体积管理。
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float baseUpwardAcceleration = 1.0f; // 基础向上加速度
    public float volume = 1.0f; // 气泡的体积
    public float sprayForceMultiplier = 10.0f; // 喷射力的倍数
    public float volumeConsumptionRate = 0.1f; // 喷射时体积消耗率
    public float constantUpwardSpeed = 1.0f; // 恒定的向上速度
    public float dragFactor = 0.95f; // 阻力因子

    private Rigidbody2D rb; // 玩家角色的刚体组件

    public static event Action OnVolumeDepleted; // 定义一个静态事件，当体积耗尽时触发

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 获取刚体组件
    }

    void FixedUpdate()
    {
        rb.velocity *= dragFactor; // 应用阻力
        float sqrtVolume = Mathf.Sqrt(volume); // 计算体积的平方根
        rb.velocity = new Vector2(rb.velocity.x, constantUpwardSpeed * sqrtVolume); // 更新速度
    }

    public float minVolume = 0.1f; // 最小体积值
    void Update()
    {
        //float sqrtVolume = Mathf.Sqrt(volume); // 计算体积的平方根
        //rb.velocity = new Vector2(rb.velocity.x, constantUpwardSpeed * sqrtVolume); // 更新速度

        if (Input.GetMouseButton(0)) // 检测鼠标输入
        {
            Spray(); // 执行喷射
        }
        
        AdjustSize(); // 根据体积调整主角大小
        
        if (volume < minVolume) // 如果体积小于0.1f，则广播事件
        {
            volume = minVolume; // 确保体积不会小于某个值
            OnVolumeDepleted?.Invoke(); // 广播事件
        }
    }
    
    /// <summary>
    /// 处理喷射逻辑，消耗体积并施加力。
    /// </summary>
    void Spray()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 获取鼠标位置
        Vector2 direction = (mousePosition - transform.position).normalized; // 计算喷射方向

        rb.AddForce(-direction * sprayForceMultiplier * volume * Time.deltaTime); // 施加喷射力

        volume -= volumeConsumptionRate * Time.deltaTime; // 消耗体积
    }

    /// <summary>
    /// 根据体积调整玩家角色的大小。
    /// </summary>
    void AdjustSize()
    {
        transform.localScale = new Vector3(volume, volume, 1); // 调整缩放
    }

    #region  Public Methods
    public void AddVolume(float amount)
    {
        volume += amount;
        AdjustSize();
    }
    public void OnHit(float volumeChange)
    {
        AddVolume(volumeChange);
        //PlaySound();
        //PlayAnimation();
    }
    #endregion
}
