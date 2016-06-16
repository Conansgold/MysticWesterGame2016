using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class GeneralButton : MonoBehaviour {

    public bool StaticButton = false;

    public bool ChangeSceneOnClick;

    public bool EndGameOnClick;

    public bool LoadAnotherMenu;

    //CHANGE STATE
    //CHANGE MENU LEVEL

    [HideInInspector]
    public int sceneIndex = 0;
    [HideInInspector]
    public string sceneName = "";
    
    public Object[] subButtons;

    public int i = 1;

	
	// Update is called once per frame
	void Update ()
    {
        ;
    }

    public void onClick()
    {
        //var generics = gameObject.transform.GetComponent<GeneralButton>();
        if (ChangeSceneOnClick)
        {
            SceneManager.LoadScene(sceneName);
        }

        if(EndGameOnClick)
        {
            endGame();
        }
    }

    void endGame()
    {
        Debug.Log("Ending Game");
        Application.Quit();
    }
}