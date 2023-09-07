using UnityEngine;
using System.Collections;

public class aimovement : MonoBehaviour {
     private Vector3 MovingDirection = Vector3.left;    //initial movement direction
     float pos1,pos2;
     int speed = 5;
     // Use this for initialization
     void Start () {
         pos1 = this.transform.position.x;

         pos2 = this.transform.position.x + 20;
     }
     
     // Update is called once per frame
     void Update () {
         UpdateMovement();
     }
     void UpdateMovement(){
         

         if (this.transform.position.x > pos2)
         {
             MovingDirection = Vector3.left;
             gameObject.GetComponent<SpriteRenderer> ().flipX = true;

         }
         else if (this.transform.position.x < pos1)
         { 
             MovingDirection = Vector3.right;
             gameObject.GetComponent<SpriteRenderer> ().flipX = false;
 
         } 
         this.transform.Translate(MovingDirection * Time.deltaTime * speed);
     }
 }
