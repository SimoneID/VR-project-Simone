using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class SavePosition : MonoBehaviour
{
    public float xPos, yPos, zPos, xRot, yRot, zRot;
    public GameObject MainCamera;
    public Vector3 LoadPosition;

    [SerializeField] float _interval = 1f;
    float _time;

    void Start()
    {
        _time = 0f;
    }

    void Update()
    {
        _time += Time.deltaTime;
        while (_time >= _interval)
        {
            Save();
            _time -= _interval;
        }
    }

    public void Save()
    {
        xPos = MainCamera.transform.position.x;
        yPos = MainCamera.transform.position.y;
        zPos = MainCamera.transform.position.z;
        xRot = MainCamera.transform.rotation.x;
        yRot = MainCamera.transform.rotation.y;
        zRot = MainCamera.transform.rotation.z;

        string filePath = @"C:\Users\simone\Documents\testfile.csv"; //On the PC at CWI
        if (!File.Exists(filePath))
        {
            // Create a file to write to.
            //string createText = "Hello and Welcome" + Environment.NewLine;
            File.WriteAllText(filePath, "xPos,yPos,zPos,xRot,yRot,zRot" + Environment.NewLine);
        }
        //var content = "testing";
        Debug.Log("Values of position are" + xPos + "," + yPos + "," + zPos);
        Debug.Log("Values of the rotation are" + xRot + "," + yRot + "," + zRot);
        File.AppendAllText(filePath, xPos + "," + yPos + "," + zPos + "," + xRot + "," + yRot + "," + zRot + Environment.NewLine);

    }
}
