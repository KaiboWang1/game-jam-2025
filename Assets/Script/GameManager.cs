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
    public float endGameDelay = 3f; // Bubble explosion time
    /// <summary>
    /// 开始游戏的函数。可以通过UI按钮调用。
    /// </summary>
    public void StartGame()
    {
        Time.timeScale = 1.0f; // 游戏时间开始流动
        StartCoroutine(StartGameDelayed());
    }

    /// <summary>
    /// 结束游戏的函数。当玩家死亡事件触发时调用。
    /// </summary>
    public void EndGame()
    {
        StartCoroutine(EndGameDelayed());
    }

    public IEnumerator EndGameDelayed()
    {
        yield return new WaitForSeconds(startGameDelay);
        SceneManager.LoadScene("EndMenu", LoadSceneMode.Single);
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
        PlayerMovement.OnEscaped += EndGame;
    }

    /// <summary>
    /// Unity生命周期方法，脚本禁用时调用。用于取消订阅事件。
    /// </summary>
    void OnDisable()
    {
        PlayerMovement.OnVolumeDepleted -= EndGame; // 取消订阅事件
        PlayerMovement.OnEscaped -= EndGame;
    }

    public IEnumerator StartGameDelayed()
    { 
        yield return new WaitForSeconds(startGameDelay);
        SceneManager.LoadScene("CupDemo",LoadSceneMode.Single);
    }
}
