using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomObjectsManager : MonoBehaviour {

    [SerializeField]
    private GameObject objectSource;

    private int currentObjectIndex = 0;

    #region Singleton

    static CustomObjectsManager instance;
    public static CustomObjectsManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<CustomObjectsManager>();

            return instance;
        }
    }

    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject CreateObject(Texture2D newTexture)
    {
        GameObject newGameObject = Instantiate(objectSource);
        newGameObject.transform.position = new Vector3(0, 10 + currentObjectIndex * 10, 0);
        newGameObject.GetComponent<Renderer>().material.mainTexture = newTexture;
        newGameObject.transform.rotation = Random.rotation;
        currentObjectIndex++;

        return newGameObject;
    }

}
