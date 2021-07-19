using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private AsyncOperation asyncOperation;
    // Start is called before the first frame update
    void Start()
    {
        asyncOperation = SceneManager.LoadSceneAsync(1);
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginButton()
    {
        asyncOperation.allowSceneActivation = true;
        SceneManager.LoadScene(1);
    }
}
