using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private VoidEventSO gameOver;
    [SerializeField] private string loseSceneName;

    private void OnEnable()
    {
        gameOver.OnEventRaised += LoadLoseScene;
    }

    private void OnDisable()
    {
        gameOver.OnEventRaised -= LoadLoseScene;
    }

    private void LoadLoseScene()
    {
        SceneManager.LoadScene(loseSceneName);
    }
}
