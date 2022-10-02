using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONStar : MonoBehaviour
{
    public TextAsset jsonFile;

    [System.Serializable]
    public class cood
    {
        public int x;
        public int y;
    }

    [System.Serializable]
    public class curves
    {
        public cood[] curve;
    }

    [System.Serializable]
    public class curveList
    {
        public curves[] data;
    }

    public curveList information_debug = new curveList();
    public static curveList information = new curveList();
    // public static Info section;

    void Start()
    {
        information_debug = JsonUtility.FromJson<curveList>(jsonFile.text);
        information = JsonUtility.FromJson<curveList>(jsonFile.text);
    }
}
