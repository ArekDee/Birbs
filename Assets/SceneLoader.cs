using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HideSceneLoaderCanvas()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
    public void LoadNextScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));

    }
    IEnumerator LoadScene(string sceneName)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        transition.SetTrigger("EndScene");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
