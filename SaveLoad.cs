using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad {

    public Game LocalCopyOfData;
    public bool IsSceneBeingLoaded = false;
    public Vector3 position;
    public Quaternion rotation;

    public void SaveData()
    {
        Debug.Log("save starting");
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("Saves/save.binary");

        LocalCopyOfData = characterController.getGame();

        formatter.Serialize(saveFile, LocalCopyOfData);

        saveFile.Close();
        Debug.Log("save finished");
    }

    public void LoadData()
    {
        Debug.Log("load started");
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);

        LocalCopyOfData = (Game)formatter.Deserialize(saveFile);
        camMouseLook.currentcam.setskele(LocalCopyOfData.skelefound);
        camMouseLook.currentcam.setmush(LocalCopyOfData.mushfound);
        camMouseLook.currentcam.setclues(LocalCopyOfData.totalfound);
        position[0] = LocalCopyOfData.PositionX;
        position[1] = LocalCopyOfData.PositionY;
        position[2] = LocalCopyOfData.PositionZ;
        rotation[0] = LocalCopyOfData.RotationX;
        rotation[1] = LocalCopyOfData.RotationY;
        rotation[2] = LocalCopyOfData.RotationZ;
        camMouseLook.currentcam.character.transform.SetPositionAndRotation(position, rotation);
        saveFile.Close();
        Debug.Log("load finished");
    }
    public void NewData()
    {
        Debug.Log("new game");
        camMouseLook.currentcam.setskele(false);
        camMouseLook.currentcam.setmush(false);
        camMouseLook.currentcam.setclues(0);
        position[0] = 131.3f;
        position[1] = 1.9f;
        position[2] = 7f;
        rotation[0] = -2.279f;
        rotation[1] = 0.204f;
        rotation[2] = -.008f;
        camMouseLook.currentcam.character.transform.SetPositionAndRotation(position, rotation);
    }
    public void EraseData()
    {
        Debug.Log("erase game");
        camMouseLook.currentcam.setskele(false);
        camMouseLook.currentcam.setmush(false);
        camMouseLook.currentcam.setclues(0);
        position[0] = 131.3f;
        position[1] = 1.9f;
        position[2] = 7f;
        rotation[0] = -2.279f;
        rotation[1] = 0.204f;
        rotation[2] = -.008f;
        camMouseLook.currentcam.character.transform.SetPositionAndRotation(position, rotation);
        SaveData();
    }
}
