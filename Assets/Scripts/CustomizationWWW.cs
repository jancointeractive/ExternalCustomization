using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Mime;
using UnityEngine.UI;

public class CustomizationWWW : MonoBehaviour
{
    [SerializeField]
    private GameObject textureObject;
    [SerializeField]
    private RawImage image;
    [SerializeField]
    private List<string> textureNames;
    [SerializeField]
    private Text text_texturesCount;
    [SerializeField]
    private Text text_rawData;
    [SerializeField]
    private Text text_pixels;
    [SerializeField]
    private Text textLoadingTime;
    private int currentTextureIndex = 0;

    private string path;
    private float loadingTime = 0;


    // Use this for initialization
    void Start ()
	{

	    path = Application.dataPath + "/../Customization/CustomizationTextures/";// Application.dataPath + "/../logo.jpg"; //

        string[] fileInfo = Directory.GetFiles(path, "*.png");


	    Debug.Log("fileInfo.Length " + fileInfo.Length);
        foreach (string s in fileInfo)
        {
            string textureName = Path.GetFileName(s);
	        textureNames.Add(textureName);
            //Debug.Log(textureName);
	    }


	    foreach (string s in textureNames)
	    {
	        ReadTexture(s);
	    }


        Debug.LogWarning ("SIZE of all textures " + bytes);
    }

    private int bytes = 0;
    private int pixels = 0;

    void ReadTexture(string texName)
    {

        string filePath = path + texName;
        //Debug.Log("filePath " + filePath);
        if (File.Exists(filePath))
        {
            // read image and store in a byte array
            byte[] byteArray = File.ReadAllBytes(filePath);
            Debug.LogWarning("SIZE of " + texName + " => " + byteArray.Length);
            //bytes += byteArray.Length;


            //create a texture and load byte array to it
            // Texture size does not matter 
            Texture2D sampleTexture = new Texture2D(2, 2);
            // the size of the texture will be replaced by image size
            bool isLoaded = sampleTexture.LoadImage(byteArray);
            // apply this texure as per requirement on image or material
            // GameObject image = GameObject.Find("RawImage");
            if (isLoaded)
            {
                bytes += sampleTexture.GetRawTextureData().Length;
                //GameObject goUITextureObject= Instantiate(image.gameObject);
                //goUITextureObject.transform.SetParent(image.gameObject.transform.parent);
                //goUITextureObject.transform.localScale = Vector3.one;
                //goUITextureObject.transform.localPosition = image.gameObject.transform.localPosition + new Vector3(333 * currentTextureIndex, 0, 0);
                //goUITextureObject.GetComponent<RawImage>().texture = sampleTexture;
                CustomObjectsManager.Instance.CreateObject(sampleTexture);

                //GameObject goTextureObject = Instantiate(textureObject);
                //goTextureObject.transform.position = new Vector3(0,5,0);
                //goTextureObject.GetComponent<Renderer>().material.mainTexture = sampleTexture;
                CustomUIObjectsManager.Instance.CreateObject(sampleTexture);
            }

            Debug.LogWarning("GetRawTextureData " + sampleTexture.GetPixels().Length);
            Debug.Log("Width " + sampleTexture.width + " | heitght: " + sampleTexture.height);
            pixels += sampleTexture.GetPixels(0).Length;

            currentTextureIndex++;
        }
        else
            Debug.LogWarning("File does not exists");


    }

	// Update is called once per frame
	void Update ()
	{
	    if (loadingTime == 0)
	        loadingTime = Time.realtimeSinceStartup;

        text_texturesCount.text = "Loaded Textures: " + currentTextureIndex;
        //textInfo.text = "Textures Memory: " + (bytes / 1000) + " MB";
	    float finalPixels = pixels / 1048576;
	    text_pixels.text = "GPU Pixels memory: " + (finalPixels * 3) + " MB";

	    float finalBytes = bytes / 1048576;
	    text_rawData.text = "GPU ARGB 32bit memory: " + (finalBytes) + " MB";

	    textLoadingTime.text = "Loading Time " + loadingTime.ToString("f1") + " sec.";

        // fdfdsf
    }
}
