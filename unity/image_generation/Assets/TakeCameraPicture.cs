using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class TakeCameraPicture : MonoBehaviour
{
    public GameObject prefab;
    public GameObject camera;

    private GameObject gameObject = null;

    private float x = 0.0f;
    private float y = 0.0f;
    private float z = 0.0f;
    private float angleMax = 360.0f;
    private float turnAmount = 30.0f;
    private string objectDesc = "unknown";
    private int imageCounter = -1;
    private int maxImages = 1024;

    private bool doInitialCircleAround = true;
    private int numCircleAround = 64;
    private bool doTakePictures = true;

    void Start()
    {
        gameObject = GameObject.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.Euler(45.0f, 60.0f, 45.0f));

        objectDesc = prefab.name;        
        if (doTakePictures) {
            string folderpath = "generated_images/" + objectDesc;

            if (!Directory.Exists(folderpath)) {
                Directory.CreateDirectory(folderpath);
            }
        }
    }

    void Update()
    {
        if (doInitialCircleAround) {
            y = y + (360.0f / (float)numCircleAround);

            if (y >= 360.0f) {
                y -= 360.0f;
            }

            if (imageCounter >= numCircleAround) {
                doInitialCircleAround = false;
            }
        }

        if (!doInitialCircleAround) {
            x = Random.Range(0.0f, angleMax);
            y = Random.Range(0.0f, angleMax);
            z = Random.Range(0.0f, angleMax);
        }

        gameObject.transform.eulerAngles = new Vector3(x, y, z);

        if (doTakePictures) {
            if ((x >= 0.0f) && (y >= 0.0f) && (z >= 0.0f) && (x <= angleMax) && (y <= angleMax) && (z <= angleMax)) {
                string filename = "generated_images/" + objectDesc + "/" + objectDesc + "_" + imageCounter.ToString("D5") + "_X" + ((int)x).ToString("D3") + "_Y" + ((int)y).ToString("D3") + "_Z" + ((int)z).ToString("D3") + ".png";
                
                if (!File.Exists(filename)) {
                    ScreenCapture.CaptureScreenshot(filename);
                    imageCounter++;
                }
            }
        }

        if (imageCounter >= maxImages) {
            doTakePictures = false;
            EditorApplication.isPlaying = false;
        }
    }
}
