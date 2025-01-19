using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// GameManager类负责管理游戏的整体流程，包括开始和结束游戏的逻辑。
/// </summary>
public class GameManager : MonoBehaviour
{
    public float startGameDelay = 1.2f;
    /// <summary>
    /// 开始游戏的函数。可以通过UI按钮调用。
    /// </summary>
    public void StartGame()
    {
        Time.timeScale = 1.0f; // 游戏时间开始流动
        StartCoroutine(StartGameDelayed());
        // 可以在这里添加其他开始游戏时需要执行的逻辑
    }

    /// <summary>
    /// 结束游戏的函数。当玩家死亡事件触发时调用。
    /// </summary>
    public void EndGame()
    {
        Time.timeScale = 0.0f; // 游戏时间暂停
        // 显示结束UI
        // 例如：endGameUI.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    /// <summary>
    /// Unity生命周期方法，脚本启用时调用。用于订阅事件。
    /// </summary>
    void OnEnable()
    {
        PlayerMovement.OnVolumeDepleted += EndGame; // 订阅事件
    }

    /// <summary>
    /// Unity生命周期方法，脚本禁用时调用。用于取消订阅事件。
    /// </summary>
    void OnDisable()
    {
        PlayerMovement.OnVolumeDepleted -= EndGame; // 取消订阅事件
    }

    public IEnumerator StartGameDelayed()
    { 
        yield return new WaitForSeconds(startGameDelay);
        SceneManager.LoadScene("CupDemo",LoadSceneMode.Single);
    }
}
