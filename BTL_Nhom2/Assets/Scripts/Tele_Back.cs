using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Tele_Back : MonoBehaviour
{
    void Start()
    {
        
    }
void OnTriggerStay2D(Collider2D other)
   {

    if (other.gameObject.name == "RuBy")
     {
        Invoke("TeleBack",2f);
	    TeleBack();
          
          
     }
   }
    // Update is called once per frame
    private void TeleBack(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    void Update()
    {
        
    }
}
