using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomUIObjectsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject objectSource;

    private int currentObjectIndex = 0;

    [SerializeField]
    private RawImage rawImage;

    [SerializeField] private Canvas canvas;
    [SerializeField] private float textureSize = 200;

    #region Singleton

    static CustomUIObjectsManager instance;
    public static CustomUIObjectsManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<CustomUIObjectsManager>();

            return instance;
        }
    }

    #endregion

    // Use this for initialization
    void Start ()
    {
        textureSize = Screen.width / 20;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    int xCount = 0;
    float x = 0, y = 0;
    public GameObject CreateObject(Texture2D newTexture)
    {
        GameObject newGameObject = Instantiate(rawImage.gameObject);
        newGameObject.transform.SetParent(canvas.transform);
        newGameObject.transform.localScale = Vector3.one;



        if (xCount * textureSize > 1920 - textureSize)
        {
            xCount = 0;
            y -= textureSize + 2;
        }
            


        x = xCount * textureSize;
        Vector2 pos = new Vector2(x , y);
        newGameObject.GetComponent<RectTransform>().anchoredPosition = pos;
        newGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(textureSize, textureSize);
        //uiTextureSize

        //newGameObject.transform.localPosition = rawImage.gameObject.transform.localPosition + new Vector3(333 * currentObjectIndex, 0, 0);

        newGameObject.GetComponent<RawImage>().texture = newTexture;

        currentObjectIndex++;
        xCount ++;


        return newGameObject;
    }
}
