using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyLoading1 : MonoBehaviour
{

    private AsyncOperation operation;
    static string level;

    public Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        operation = SceneManager.LoadSceneAsync(level);
        operation.allowSceneActivation = false;
        Invoke("AllowScene", 2);

    }

    void AllowScene()
    {
        operation.allowSceneActivation = true;
    }


    void Update()
    {
        slider.value = Mathf.Lerp(slider.value, operation.progress, Time.deltaTime*4);    
    }

    public static void LoadLevel(string nextLevel)
    {
        level = nextLevel;
        SceneManager.LoadScene("Loading");
    }
}
