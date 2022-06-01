using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class MapLoad : MonoBehaviour
{
    public GameObject thisPart;
    //static XmlDocument myXmlString;
    // Start is called before the first frame update
    void Start()
    {
        LOADMAP();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LOADMAP(){
        XmlDocument xml = new XmlDocument();
        xml.Load("https://www.planetarium.digital/games/maps/map.xml");
        /*XmlDocument doc = new XmlDocument();
        doc.Load("http://down-hill.ml/map.xml");
        XmlNodeList lst = doc.GetElementsByTagName("game");

        foreach (XmlElement elem in lst)
        {
            XmlNode partXML = doc.GetElementsByTagName("part")[0];
            thisPart = GameObject.CreatePrimitive(PrimitiveType.Cube);
            elem.Descendants("tag");
            //HEAD.color = ColorUtility.TryParseHtmlString(headXML.InnerText, out HEADcolor);
        }
        //Console.WriteLine("Got "+NameXML+" Version");
        //System.Threading.Thread.Sleep(1500);*/
        /*XmlDocument xml = new XmlDocument();
        xml.LoadXml(myXmlString.ToString());*/ // suppose that myXmlString contains "<Names>...</Names>"
        XmlNodeList xnList = xml.SelectNodes("/game/part");
        foreach (XmlNode xn in xnList)
        {
            string name = xn["name"].InnerText;
            string anchored = xn["anchored"].InnerText;
            int sizeX = int.Parse(xn["sizeX"].InnerText);
            int sizeY = int.Parse(xn["sizeY"].InnerText);
            int sizeZ = int.Parse(xn["sizeZ"].InnerText);
            int posX = int.Parse(xn["posX"].InnerText);
            int posY = int.Parse(xn["posY"].InnerText);
            int posZ = int.Parse(xn["posZ"].InnerText);
            int rotX = int.Parse(xn["rotX"].InnerText);
            int rotY = int.Parse(xn["rotY"].InnerText);
            int rotZ = int.Parse(xn["rotZ"].InnerText);
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
            if(anchored == "false"){
                Rigidbody body = thisPart.AddComponent<Rigidbody>();
            }
            attrs.WasApplied = true;
            //end of color lol
            //thisPart = null;
            //print(thisPart.transform.localScale+" "+thisPart.transform.position);
        }
    }
}

