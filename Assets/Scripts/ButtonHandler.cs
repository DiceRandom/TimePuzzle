using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonHandler : MonoBehaviour
{

    public UnityEvent button;
    public bool Lever;
    bool leverdisable;
    public Transform model;

    public Transform Trails;



    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            
            if(Lever && !leverdisable){
                leverdisable = true;
                button.Invoke();
                HandlerModel();
                foreach (Transform child in Trails)
                {
                    child.GetComponent<SpriteRenderer>().color = Color.red;
                }
                return;
            }
            if(!Lever){
                button.Invoke();
                return;
            }
        }
    }

    public void HandlerModel(){
        model.GetComponent<Animator>().SetTrigger("Down");
    }
}
