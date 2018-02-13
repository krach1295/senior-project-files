using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class camMouseLook : MonoBehaviour
{
    public static camMouseLook currentcam;
    Vector2 mouseLook;
    Vector2 smoothV;
    int a;
    int b;
    int i;
    int j;
    int k;
    int l;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public RawImage notifimg;
    public RawImage[] notif;
    public Text[] texts;
    Image[] images;
    public bool menu;
    public GameObject character;

    public Text skeletontext;
    public Text mushtext;
    public Text alreadyfound;

    public int cluesgot = 0;
    public bool skelegot = false;
    public bool mushgot = false;

    

    void Start()
    {
        character = this.transform.parent.gameObject;
        currentcam = FindObjectOfType<camMouseLook>();
        //DontDestroyOnLoad(character);
        //Light lite = FindObjectOfType<Light>();
        //DontDestroyOnLoad(lite);
    }
    public int getclues()
    {
        return cluesgot;
    }
    public bool getskele()
    {
        return skelegot;
    }
    public bool getmush()
    {
        return mushgot;
    }
    public void setskele(bool b)
    {
        skelegot = b;
    }

    public void setmush(bool b)
    {
        mushgot = b;
    }

    public void setclues(int i)
    {
        cluesgot = i;
    }

    void wipe1()
    {
        notifimg.enabled = false;
        skeletontext.enabled = false;
        i = 0;
    }

    void wipe2()
    {
        notifimg.enabled = false;
        mushtext.enabled = false;
        i = 0;
    }

    void wipefound()
    {
        notifimg.enabled = false;
        alreadyfound.enabled = false;
        i = 0;
    }

    

    void Update()
    {
        
        images = FindObjectsOfType<Image>();
        a = 0;
        b = images.Length;
        while (a < b)
        {
            if (images[a].tag == "menuimage")
            {
                menu = images[a].enabled;
            }
            if (images[a].name == "skelegot" && skelegot == true)
            {
                images[a].enabled = true;
            }
            if (images[a].name == "mushgot" && mushgot == true)
            {
                images[a].enabled = true;
            }
            a += 1;
        }
        if (menu == false)
        {
            if ((Input.GetAxis("Mouse X") != 0) & (Input.GetAxis("Mouse Y") != 0))
            {
                var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
                smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
                smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
                mouseLook += smoothV;
                mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
                transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
                character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
            }
         }

            if (Input.GetMouseButtonDown(0))
            {
                Camera cam = GetComponent<Camera>();
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    // the object identified by hit.transform was clicked
                    if ((hit.transform.gameObject.tag == "skeleman") && (skelegot == false))
                    {
                        notif = FindObjectsOfType<RawImage>();
                        k = 0;
                        l = notif.Length;
                        while (k < l)
                        {
                            if(notif[k].tag == "notifimg")
                            {
                                notifimg = notif[k];
                                notifimg.enabled = true;
                            }
                            k += 1;
                        }
                        texts = FindObjectsOfType<Text>();
                        i = 0;
                        j = texts.Length;
                        while (i < j)
                        {
                            if (texts[i].tag == "skeletext")
                            {
                                //print("skeletext found");
                                skeletontext = texts[i];
                                skeletontext.enabled = true;
                            }
                            i = i + 1;
                        }
                        skelegot = true;
                        cluesgot += 1;
                        Invoke("wipe1", 4);
                    }

                    else if ((hit.transform.gameObject.tag == "skeleman") && (skelegot == true))
                    {
                        notif = FindObjectsOfType<RawImage>();
                        k = 0;
                        l = notif.Length;
                        while (k < l)
                        {
                            if (notif[k].tag == "notifimg")
                            {
                                notifimg = notif[k];
                                notifimg.enabled = true;
                            }
                            k += 1;
                        }
                        texts = FindObjectsOfType<Text>();
                        i = 0;
                        j = texts.Length;
                        while (i < j)
                        {
                            if (texts[i].tag == "alreadyfound")
                            {
                                //print("already found skele");
                                alreadyfound = texts[i];
                                alreadyfound.enabled = true;
                            }
                            i = i + 1;
                        }
                        Invoke("wipefound", 4);
                    }

                    if ((hit.transform.gameObject.tag == "mushbite") && (mushgot == false))
                    {
                        notif = FindObjectsOfType<RawImage>();
                        k = 0;
                        l = notif.Length;
                        while (k < l)
                        {
                            if (notif[k].tag == "notifimg")
                            {
                                notifimg = notif[k];
                                notifimg.enabled = true;
                            }
                            k += 1;
                        }
                        texts = FindObjectsOfType<Text>();
                        i = 0;
                        j = texts.Length;
                        while (i < j)
                        {
                            if (texts[i].tag == "mushtext")
                            {
                                //print("mushrooms found");
                                mushtext = texts[i];
                                mushtext.enabled = true;
                            }
                            i = i + 1;
                        }
                        mushgot = true;
                        cluesgot += 1;
                        Invoke("wipe2", 4);
                    }

                    else if ((hit.transform.gameObject.tag == "mushbite") && (mushgot == true))
                    {
                        notif = FindObjectsOfType<RawImage>();
                        k = 0;
                        l = notif.Length;
                        while (k < l)
                        {
                            if (notif[k].tag == "notifimg")
                            {
                                notifimg = notif[k];
                                notifimg.enabled = true;
                            }
                            k += 1;
                        }
                        texts = FindObjectsOfType<Text>();
                        i = 0;
                        j = texts.Length;
                        while (i < j)
                        {
                            if (texts[i].tag == "alreadyfound")
                            {
                                //print("already found mush");
                                alreadyfound = texts[i];
                                alreadyfound.enabled = true;
                            }
                            i = i + 1;
                        }
                        Invoke("wipefound", 4);
                    }


                    
                }
            }
        
    }
}


