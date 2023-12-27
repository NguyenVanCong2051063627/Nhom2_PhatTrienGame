using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
     public AudioClip collectedClip;

     // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {

     }
     void OnTriggerEnter2D(Collider2D other)
     {
          RubyControll controller = other.GetComponent<RubyControll>();

          if (controller != null)
          {
               if (controller.health < controller.maxHealth)
               {
                    controller.ChangeHealth(1);
                    Destroy(gameObject);
                    controller.PlaySound(collectedClip);
               }
          }
     }
}

