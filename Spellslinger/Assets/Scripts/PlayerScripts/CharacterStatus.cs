using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public GameObject DeathScreenUI;
    void Awake()
    {
        DeathScreenUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void DeathScreen()
    {
        Time.timeScale = 0f;
        DeathScreenUI.SetActive(true);
    }
}
