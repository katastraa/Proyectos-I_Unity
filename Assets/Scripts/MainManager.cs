using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

    public int completado = 0;

    public static MainManager instancia = null;

    public int currentLevel = 0;

    private void Awake() {
        // start of new code
        if (MainManager.instancia != null) {
            Destroy(this);
            return;
        }
        // end of new code
        MainManager.instancia = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadSceneIndex(int sceneIndex) {
        currentLevel = sceneIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadNextLevelNum() {
        currentLevel = 1 + currentLevel;
        LoadSceneIndex(currentLevel);
    }

    public void LoadCurrentLevelNum()
    {
        LoadSceneIndex(currentLevel);
    }

    public void LoadCurrentScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadReset() {
        currentLevel = 0;
        LoadSceneIndex(currentLevel);
    }



    public void LoadSceneString(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame(){
        Application.Quit();
    }

    private void OnDestroy() {
        Debug.Log("Me ha destruido" + this.gameObject.name);    
    }

}
