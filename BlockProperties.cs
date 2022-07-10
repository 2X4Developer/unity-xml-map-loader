using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockProperties : MonoBehaviour
{
    public Vector3 THISPosition;
    public Vector3 THISScale;
    public Vector3 THISRotation;
    public Color ColorBL;
    public bool WasApplied;
    public bool WasSet;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke ("applyProperties", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(WasApplied == true && WasSet == false){
            applyProperties();
        }
    }

    public void applyProperties(){
        if(WasSet == false){
            transform.position = THISPosition;
            transform.localScale = THISScale;
            transform.localRotation = Quaternion.Euler(THISRotation);
            GetComponent<Renderer>().material.color = ColorBL;
            GetComponent<Renderer>().material.SetFloat("_Glossiness", 0);
            WasSet = true;
        }
    }
}
