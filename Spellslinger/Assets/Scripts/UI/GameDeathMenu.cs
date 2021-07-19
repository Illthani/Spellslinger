using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDeathMenu : MonoBehaviour
{
    [SerializeField] private GameObject CanvasField;
    private AsyncOperation asyncOperation;

    // Start is called before the first frame update
    void Start()
    {
//        asyncOperation = SceneManager.LoadSceneAsync(0);
//        //Don't let the Scene activate until you allow it to
//        asyncOperation.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(1);
//        asyncOperation.allowSceneActivation = true;
        CanvasField.SetActive(false);
    }
}
