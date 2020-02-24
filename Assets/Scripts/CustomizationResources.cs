using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationResources : MonoBehaviour
{
    [SerializeField] private GameObject go;

    [SerializeField]
    private Text text;

    [SerializeField]
    private Object[] objects;
    private Texture2D[] textures;

    void Start()
    {
        objects = Resources.LoadAll(""); //Textures
        
        textures = Resources.LoadAll<Texture2D>("");
        //textures = Resources.LoadAll("");

        //foreach (Texture2D t in textures)
        //{
        //    Debug.Log(t.name);
        //}

        //foreach (var t in textures)
        //{
        //    Debug.Log(t.name);
        //}


        //string texturePath = "Assets/Resources/Textures/Turner.png";
        Texture2D tex2D = Resources.Load<Texture2D>("logo2");
        if (tex2D)
            go.GetComponent<Renderer>().material.mainTexture = tex2D;

        Texture tex = Resources.Load("logo") as Texture;
        if (tex)
            go.GetComponent<Renderer>().material.mainTexture = tex;
    }

    void Update()
    {
        //text.text = "textures.Length " + textures.Length + " | objects.Length " + objects.Length;
    }

    //void OnGUI()
    //{
    //    if (GUI.Button(new Rect(10, 70, 150, 30), "Change texture"))
    //    {
    //        // change texture on cube

    //        Texture2D texture = (Texture2D)textures[Random.Range(0, textures.Length)];
    //        if (texture)
    //            go.GetComponent<Renderer>().material.mainTexture = texture;
    //    }
    //}
}
