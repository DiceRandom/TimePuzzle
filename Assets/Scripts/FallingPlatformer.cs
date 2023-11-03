using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformer : MonoBehaviour
{


    public float timer = 10f;
 
    public bool isTouched = false;
    public float tempTimer;
    public bool Disable
    {
        get { return _disable; }
        set
        {_disable = value; }
    }

    private bool _disable;
    public bool Paused
    {
        get { return _paused; }
        set
        {_paused = value; }
    }

    private bool _paused;
 
    private void Start() => tempTimer = timer;
 
 
    private void Update()
    {
        if (!isTouched || _disable || _paused) return;
        tempTimer -= Time.deltaTime;
 
        if (!(tempTimer <= 0)) return;
        
        Debug.Log("fall.");
        transform.parent.gameObject.AddComponent<Rigidbody2D>();
        isTouched = false;
        tempTimer = timer;
    }
 
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Player"){
            if (isTouched || _disable || _paused) return;
            isTouched = !isTouched;
            Debug.Log("collided");
        }
    }
}
