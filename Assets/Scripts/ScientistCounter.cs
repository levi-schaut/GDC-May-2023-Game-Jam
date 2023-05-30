using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScientistCounter : MonoBehaviour
{
    public int scientistsExtracted;

    public Image UIscientist1;
    public Image UIscientist2;
    public Image UIscientist3;

    private void Awake()
    {   
        scientistsExtracted = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIscientist1.enabled = false;
        UIscientist2.enabled = false;
        UIscientist3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Scientist 1") == null)
        {
            UIscientist1.enabled = true;
        }

        if (GameObject.Find("Scientist 2") == null)
        {
            UIscientist2.enabled = true;
        }

        if (GameObject.Find("Scientist 3") == null)
        {
            UIscientist3.enabled = true;
        }
    }

    public void scientistCount(int amount)
    {
        scientistsExtracted += amount;
    }
}
