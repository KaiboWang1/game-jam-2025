using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpriteSwitcher : MonoBehaviour
{
    public List<Sprite> sprites;  // 存储多个Sprite的List
    private Image spriteRenderer;
    [SerializeField]
    private float switchTime = 0.5f;  // 每次切换的时间间隔
    private float timeElapsed = 0f;
    private int currentIndex = 0;  // 当前显示的Sprite索引

    void Start()
    {
        spriteRenderer = GetComponent<Image>();

        if (sprites.Count > 0)
        {
            spriteRenderer.sprite = sprites[currentIndex];  // 初始显示第一个Sprite
        }
        else
        {
            Debug.LogWarning("Sprite list is empty!");
        }
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;  // 累加时间

        if (timeElapsed >= switchTime)
        {
            // 切换到下一个Sprite
            currentIndex = (currentIndex + 1) % sprites.Count;  // 使用模运算确保循环
            spriteRenderer.sprite = sprites[currentIndex];

            timeElapsed = 0f;  // 重置时间
        }
    }
}
