using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazehealth : MonoBehaviour
{
       public AudioClip collectedClip;
    void OnTriggerEnter2D(Collider2D other)
{
    RubyControll controller = other.GetComponent<RubyControll>();

    if (controller != null)
    {
        Destroy(gameObject);
          controller.PlaySound(collectedClip);
    }
}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
