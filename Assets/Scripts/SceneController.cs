﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Scene1"); //lub numer sceny
    }
}
