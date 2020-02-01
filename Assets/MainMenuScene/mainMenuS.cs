using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;





public class mainMenuS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void performChange()
    {
        string buttonName = EventSystem.current.
                            currentSelectedGameObject.name;
        if (buttonName.Equals("creditsButton"))
            SceneManager.LoadScene("creditsScene");
        else
        {
            //Level_Scene
            string whatToLoad = buttonName.Equals("playButton") ? "Level_Scene" : "HowToScreen";
            SceneManager.LoadScene(whatToLoad);

        }


    }
}
