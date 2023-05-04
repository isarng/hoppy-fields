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
      canvasText2.enabled = false;
      canvasText3.enabled = false;
      Invoke("DisableText", 10f);//invoke after 5 seconds
      Invoke("EnableText2", 10f);
      Invoke("DisableText2", 20f);
      Invoke("EnableText3", 20f);
      Invoke("DisableText3",30f);
   }
   void DisableText()
   {
      canvasText1.enabled = false;

   }

   void EnableText2(){
      canvasText2.enabled = true;
   }

   void DisableText2()
   {
      canvasText2.enabled = false;

   }

   void EnableText3(){
      canvasText3.enabled = true;
   }
   
   void DisableText3()
   {
      canvasText3.enabled = false;

   }

}
 