using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class mainmenucontrol : MonoBehaviour {

    Button[] buttons;
    Button newbutton;
    Button loadbutton;
    Button erasebutton;
    UnityAction newopener;
    UnityAction loadopener;
    UnityAction eraseopener;
    int l;
    int m;
    SaveLoad saveload = new SaveLoad();

	// Use this for initialization
	void Start () {
        buttons = FindObjectsOfType<Button>();
        l = buttons.Length;
        while (m < l)
        {
            if(buttons[m].name == "newgame")
            {
                newbutton = buttons[m];
            }
            if(buttons[m].name == "loadgame")
            {
                loadbutton = buttons[m];
            }
            if(buttons[m].name == "erasedata")
            {
                erasebutton = buttons[m];
            }
            m += 1;
        }
        newopener += newgame;
        newbutton.onClick.AddListener(newopener);
        loadopener += loadgame;
        loadbutton.onClick.AddListener(loadopener);
        eraseopener += erasegame;
        erasebutton.onClick.AddListener(eraseopener);
    }
	
    public void newgame()
    {
        
        SceneManager.LoadScene("Level 1");
        saveload.NewData();
    }
    public void loadgame()
    {
        
        SceneManager.LoadScene("Level 1");
        saveload.LoadData();
    }
    public void erasegame()
    {
        SceneManager.LoadScene("Level 1");
        saveload.EraseData();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
