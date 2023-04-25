using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextFader : MonoBehaviour
{

   public Text canvasText1;
   public Text canvasText2;
   public Text canvasText3;

   void Start ()
   {
      Invoke("DisableText", 10f);//invoke after 5 seconds
   }
   void DisableText()
   {
      canvasText1.enabled = false;

   }
   
}
 