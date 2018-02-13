using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;


public class characterController : MonoBehaviour {

    public static characterController currentcontroller;
    public static camMouseLook currentcam;
    public float speed = 10.0f;
    //public OpenMenu menu;

    public bool menuOpen;
    public Image[] buttons;
    public Button[] buttonsclick;
    public Text[] buttonswords;
    public Button HelpButton = null;
    UnityEvent help;
    public Button SaveButton = null;
    UnityEvent save;
    public Button LoadButton = null;
    UnityEvent load;
    public Button JournalButton = null;
    UnityEvent journal;
    public Button MainMenuButton = null;
    UnityEvent mainMenu;
    public SaveLoad saveload = new SaveLoad();
    int g;
    int h;
    int i;
    int j;
    int k;
    int l;
    RawImage[] helpimgs;
    Text[] helptxts;
    RawImage[] journalpage;
    Text[] journaltxts;
    Button[] journalbutts;
    RawImage[] unlocked;
    List<Text> pages = new List<Text>();
    public Button journalNext = null;
    public Button journalPrev = null;
    bool skelegot;
    bool mushgot;
    RawImage[] rawimgs;
    Text[] txts;
    RawImage notif;
    Text note;
    int a;
    int b;
    int c;
    int z;
    int z2;
    int z3;
    int z4;
    int y;
    int x;
    int w;
    int v;
    bool helpopen = false;
    bool journalopen = false;
    UnityAction helpopener;
    UnityAction saveopener;
    UnityAction loadopener;
    UnityAction journalopener;
    UnityAction menuopener;

    RawImage[] rawimages;
    Text[] texts;
    Button[] butts;
    Image[] images;
    Text nonepage;
    Text skelepage;
    Text mushpage;
    RawImage pageimage;
    UnityAction next;
    UnityAction prev;


    //camMouseLook currentcam;
    public GameObject character;
    public Game currentgame = new Game();
    public static Game present;

    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        menuOpen = false;
        //helpopener += openHelp;
        character = gameObject;
        currentcam = FindObjectOfType<camMouseLook>();
        buttonsclick = FindObjectsOfType<Button>();
        h = buttonsclick.Length;
        while (g < h)
        {
            if (buttonsclick[g].name == "HelpButton")
            {
                HelpButton = buttonsclick[g];
            }
            if (buttonsclick[g].name == "JournalButton")
            {
                JournalButton = buttonsclick[g];
            }
            if (buttonsclick[g].name == "SaveButton")
            {
                SaveButton = buttonsclick[g];
            }
            if (buttonsclick[g].name == "LoadButton")
            {
                LoadButton = buttonsclick[g];
            }
            if (buttonsclick[g].name == "MainMenuButton")
            {
                MainMenuButton = buttonsclick[g];
            }
            g += 1;
        }
        helpopener += openHelp;
        HelpButton.onClick.AddListener(helpopener);
        saveopener += openSave;
        SaveButton.onClick.AddListener(saveopener);
        loadopener += openLoad;
        LoadButton.onClick.AddListener(loadopener);
        journalopener += openJournal;
        JournalButton.onClick.AddListener(journalopener);
        menuopener += openMainMenu;
        MainMenuButton.onClick.AddListener(menuopener);
    }

    public static Game getGame()
    {
        return present;
    }

    void Update() {
        if (menuOpen == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey("left shift") | Input.GetKey("right shift"))
            {
                speed = 20.0f;
            }
            else
            {
                speed = 10.0f;
            }
            float translation = Input.GetAxis("Vertical") * speed;
            float straffe = Input.GetAxis("Horizontal") * speed;
            translation *= Time.deltaTime;
            straffe *= Time.deltaTime;

            transform.Translate(straffe, 0, translation);
        }
        else
        {
            speed = 0f;
        }



        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("tab") && menuOpen == false)
        {
            openmenu();
        }
        else if (Input.GetKeyDown("tab") && helpopen == true)
        {
            closemenu();
            closehelp();
        }
        else if (Input.GetKeyDown("tab") && journalopen == true)
        {
            closemenu();
            closeJournal();
        }
        else if (Input.GetKeyDown("tab") && menuOpen == true)
        {
            closemenu();
        }
    }

    public void openHelp()
    {
        helpimgs = FindObjectsOfType<RawImage>();
        helptxts = FindObjectsOfType<Text>();
        z = 0;
        z2 = 0;
        y = helpimgs.Length;
        x = helptxts.Length;
        while (z < y)
        {
            if(helpimgs[z].tag == "helptext")
            {
                helpimgs[z].enabled = true;
            }
            z += 1;
        }
        while (z2 < x)
        {
            if (helptxts[z2].tag == "helptext")
            {
                helptxts[z2].enabled = true;
            }
            z2 += 1;
        }
        helpopen = true;
        //return helpopener;
    }
    public void closehelp()
    {
        helpimgs = FindObjectsOfType<RawImage>();
        helptxts = FindObjectsOfType<Text>();
        z = 0;
        z2 = 0;
        y = helpimgs.Length;
        x = helptxts.Length;
        while (z < y)
        {
            if (helpimgs[z].tag == "helptext")
            {
                helpimgs[z].enabled = false;
            }
            z += 1;
        }
        while (z2 < x)
        {
            if (helptxts[z2].tag == "helptext")
            {
                helptxts[z2].enabled = false;
            }
            z2 += 1;
        }
        helpopen = false;
    }

    public void wipe()
    {
        notif.enabled = false;
        note.enabled = false;
    }

    public void openSave()
    {
        print("save clicked");
        currentgame.skelefound = currentcam.getskele();
        currentgame.mushfound = currentcam.getmush();
        currentgame.totalfound = currentcam.getclues();
        currentgame.PositionX = character.transform.position[0];
        currentgame.PositionY = character.transform.position[1];
        currentgame.PositionZ = character.transform.position[2];
        currentgame.RotationX = character.transform.rotation[0];
        currentgame.RotationY = character.transform.rotation[1];
        currentgame.RotationZ = character.transform.rotation[2];
        present = currentgame;
        saveload.SaveData();
        rawimgs = FindObjectsOfType<RawImage>();
        txts = FindObjectsOfType<Text>();
        b = rawimgs.Length;
        c = txts.Length;
        a = 0;
        while (a < b)
        {
            if(rawimgs[a].tag == "notifimg")
            {
                notif = rawimgs[a];
                notif.enabled = true;
            }
            a += 1;
        }
        a = 0;
        while (a < c)
        {
            if(txts[a].tag == "saved")
            {
                note = txts[a];
                note.enabled = true;
            }
            a += 1;
        }
        Invoke("wipe", 4);
        //return saveopener;
    }

    public void openLoad()
    {
        print("load clicked");
        saveload.LoadData();
        rawimgs = FindObjectsOfType<RawImage>();
        txts = FindObjectsOfType<Text>();
        b = rawimgs.Length;
        c = txts.Length;
        a = 0;
        while (a < b)
        {
            if (rawimgs[a].tag == "notifimg")
            {
                notif = rawimgs[a];
                notif.enabled = true;
            }
            a += 1;
        }
        a = 0;
        while (a < c)
        {
            if (txts[a].tag == "loaded")
            {
                note = txts[a];
                note.enabled = true;
            }
            a += 1;
        }
        Invoke("wipe", 4);
        //return loadopener;
    }

   public void nextbutton()
    {

    }
    public void prevbutton()
    {

    }

    public void openJournal()
    {
        print("journal open");
        journalopen = true;
        rawimages = FindObjectsOfType<RawImage>();
        texts = FindObjectsOfType<Text>();
        butts = FindObjectsOfType<Button>();
        images = FindObjectsOfType<Image>();
        v = rawimages.Length;
        w = texts.Length;
        x = butts.Length;
        y = images.Length;
        z = 0;
        z2 = 0;
        z3 = 0;
        z4 = 0;
        //raw image
        while (z < v) 
        {
            if (rawimages[z].tag == "journalpage")
            {
                pageimage = rawimages[z];
                pageimage.enabled = true;
            }
            z++;
        }
        //texts
        while (z2 < w)
        {
            if (texts[z2].tag == "journaltext")
            {
                if (texts[z2].name.Equals("nonepage"))
                {
                    nonepage = texts[z2];
                    pages.Add(texts[z2]);
                    nonepage.enabled = true;
                }
                if (texts[z2].name.Equals("skelepage") && skelegot == true)
                {
                    skelepage = texts[z2];
                    pages.Add(texts[z2]);
                }
                if (texts[z2].name.Equals("mushpage") && mushgot == true)
                {
                    mushpage = texts[z2];
                    pages.Add(texts[z2]);
                }
            }
            if (texts[z2].tag == "journalbutton")
            {
                texts[z2].enabled = true;
            }
            z2++;
        }
        //buttons
        while (z3 < x)
        {
            if (butts[z3].tag == "journalbutton")
            {
                //butts[z3].enabled = true;
                if (butts[z3].name.Equals("next"))
                {
                    journalNext = butts[z3];
                    journalNext.enabled = true;

                    next += nextbutton;
                    journalNext.onClick.AddListener(next);
                }
                if (butts[z3].name.Equals("prev"))
                {
                    journalPrev = butts[z3];
                    journalPrev.enabled = true;

                    prev += prevbutton;
                    journalPrev.onClick.AddListener(prev);
                }
            }
            z3++;
        }
        while (z4 < y)
        {
            if (images[z4].tag == "journalbutton")
            {
                images[z4].enabled = true;
            }
            z4++;
        }
    }

    public void closeJournal()
    {
        print("journal close");
        journalopen = false;
        rawimages = FindObjectsOfType<RawImage>();
        texts = FindObjectsOfType<Text>();
        butts = FindObjectsOfType<Button>();
        images = FindObjectsOfType<Image>();
        v = rawimages.Length;
        w = texts.Length;
        x = butts.Length;
        y = images.Length;
        z = 0;
        z2 = 0;
        z3 = 0;
        z4 = 0;
        //raw image
        while (z < v)
        {
            if (rawimages[z].tag == "journalpage")
            {
                rawimages[z].enabled = false;
            }
            z++;
        }
        //texts
        while (z2 < w)
        {
            if (texts[z2].tag == "journaltext")
            {
                texts[z2].enabled = false;
            }
            if (texts[z2].tag == "journalbutton")
            {
                texts[z2].enabled = false;
            }
            z2++;
        }
        //buttons
        while (z3 < x)
        {
            if (butts[z3].tag == "journalbutton")
            {
                    butts[z3].enabled = false;
            }
            z3++;
        }
        while (z4 < y)
        {
            if (images[z4].tag == "journalbutton")
            {
                images[z4].enabled = false;
            }
            z4++;
        }
    }

   
    public void openMainMenu()
    {
        print("main menu clicked");
        SceneManager.LoadScene("mainmenu");
        //return menuopener;
    }

    public void openmenu()
    {
        //print("opening");
        g = 0;
        i = 0;
        k = 0;
        buttons = FindObjectsOfType<Image>();
        buttonswords = FindObjectsOfType<Text>();
        buttonsclick = FindObjectsOfType<Button>();
        h = buttonsclick.Length;
        while (g < h)
        {
            if (buttonsclick[g].tag == "menubutt")
            {
                buttonsclick[g].enabled = true;
            }
            
            g += 1;
        }
        j = buttons.Length;
        while (i < j)
        {
            if (buttons[i].tag == "menubutt")
            {
                buttons[i].enabled = true;
            }
            if (buttons[i].tag == "menuimage")
            {
                buttons[i].enabled = true;
            }
            i += 1;
        }
        l = buttonswords.Length;
        while (k < l)
        {
            if (buttonswords[k].tag == "menutext")
            {
                buttonswords[k].enabled = true;
            }
            k += 1;
        }
        Cursor.lockState = CursorLockMode.None;
        menuOpen = true;
        //print("open = " + menuOpen);
    }

    public void closemenu()
    {
        //print("closing");
        g = 0;
        i = 0;
        k = 0;

        buttons = FindObjectsOfType<Image>();
        buttonswords = FindObjectsOfType<Text>();
        buttonsclick = FindObjectsOfType<Button>();
        h = buttonsclick.Length;
        while (g < h)
        {
            if (buttonsclick[g].tag == "menubutt")
            {
                buttonsclick[g].enabled = false;
            }
            g += 1;
        }

        j = buttons.Length;
        while (i < j)
        {
            if (buttons[i].tag == "menubutt")
            {
                buttons[i].enabled = false;
            }
            if (buttons[i].tag == "menuimage")
            {
                buttons[i].enabled = false;
            }
            i += 1;
        }

        l = buttonswords.Length;
        while (k < l)
        {
            if (buttonswords[k].tag == "menutext")
            {
                buttonswords[k].enabled = false;
            }
            k += 1;
        }

        menuOpen = false;
        //print("buttons length = " + h + ", words length = " + l + ", images length = " + j);
        //print("loop 1 length = " + g + ", loop 2 length =" + k + ", loop 3 length = " + i);
        Cursor.lockState = CursorLockMode.Locked;
        
        //print("open = " + menuOpen);
    }

    public bool isopen()
    {
        if (menuOpen == true)
        {
            return true;
        }
        if (menuOpen == false)
        {
            return false;
        }
        else
        {
            print("isopen returned neither true nor false");
            return false;
        }
    }





}


