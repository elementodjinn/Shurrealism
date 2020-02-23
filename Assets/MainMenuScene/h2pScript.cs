using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class h2pScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goBack()
    {
        string buttonName = EventSystem.current.
                            currentSelectedGameObject.name;
        if (buttonName.Equals("backButton"))
            SceneManager.LoadScene("mainMenuScene2");

    }

}
