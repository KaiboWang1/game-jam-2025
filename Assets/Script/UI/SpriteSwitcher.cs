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
    public bool isLooping = false;
    public bool isActive = false;

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
        if (isActive)
        {
            timeElapsed += Time.deltaTime;  // 累加时间

            if (timeElapsed >= switchTime)
            {
                // 切换到下一个Sprite
                if (isLooping)
                {
                    currentIndex = (currentIndex + 1) % sprites.Count;  // 使用模运算确保循环
                }
                else
                {
                    currentIndex = currentIndex < sprites.Count - 1 ? currentIndex + 1 : sprites.Count - 1;
                }

                spriteRenderer.sprite = sprites[currentIndex];

                timeElapsed = 0f;  // 重置时间
            }
        }
    }

    public void PlayFromStart()
    {
        isActive = true;
        currentIndex = 0;
    }
}
