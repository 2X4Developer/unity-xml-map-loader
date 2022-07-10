using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Globalization;

public class MapLoad : MonoBehaviour
{
    public GameObject thisPart;
    public string LoadPath;

    void Start()
    {
        LOADMAP();
    }

    public void LOADMAP(){
        XmlDocument xml = new XmlDocument();
        xml.Load(LoadPath);
        XmlNodeList xnList = xml.SelectNodes("/game/part");
        foreach (XmlNode xn in xnList)
        {
            string name = xn["name"].InnerText;
            string anchored = xn["anchored"].InnerText;
            float sizeX = float.Parse(xn["sizeX"].InnerText, CultureInfo.InvariantCulture.NumberFormat);
            float sizeY = float.Parse(xn["sizeY"].InnerText, CultureInfo.InvariantCulture.NumberFormat);
            float sizeZ = float.Parse(xn["sizeZ"].InnerText, CultureInfo.InvariantCulture.NumberFormat);
            float posX = float.Parse(xn["posX"].InnerText, CultureInfo.InvariantCulture.NumberFormat);
            float posY = float.Parse(xn["posY"].InnerText, CultureInfo.InvariantCulture.NumberFormat);
            float posZ = float.Parse(xn["posZ"].InnerText, CultureInfo.InvariantCulture.NumberFormat);
            float rotX = float.Parse(xn["rotX"].InnerText, CultureInfo.InvariantCulture.NumberFormat);
            float rotY = float.Parse(xn["rotY"].InnerText, CultureInfo.InvariantCulture.NumberFormat);
            float rotZ = float.Parse(xn["rotZ"].InnerText, CultureInfo.InvariantCulture.NumberFormat);
            thisPart = GameObject.CreatePrimitive(PrimitiveType.Cube);
            thisPart.name = name;
            BlockProperties attrs = thisPart.AddComponent<BlockProperties>();
            attrs.THISScale = new Vector3(sizeX, sizeY, sizeZ);
            attrs.THISPosition = new Vector3(posX, posY, posZ);
            attrs.THISRotation = new Vector3(rotX, rotY, rotZ);
            //color now
            string hexString = xn["color"].InnerText;
            Color myColor = new Color();
            ColorUtility.TryParseHtmlString(hexString, out myColor);
            attrs.ColorBL = myColor;
            thisPart.tag = "Part";
            if(anchored == "false"){
                Rigidbody body = thisPart.AddComponent<Rigidbody>();
            }
            attrs.WasApplied = true;
        }
    }
}
