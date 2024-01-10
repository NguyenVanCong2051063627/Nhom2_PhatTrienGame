using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
void OnTriggerStay2D(Collider2D other)
   {

    if (other.gameObject.name == "RuBy")
     {
        Invoke("CompleteLevel", 2f); 
     }
   }
    // Update is called once per frame
    private void CompleteLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Update()
    {
        
    }
}
