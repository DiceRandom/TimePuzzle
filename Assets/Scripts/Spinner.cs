using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    public Vector3 rotator;
    public float speed;

    public bool Disabled
    {
        get {return _disabled;}
        set {_disabled = value;}
    }
    private bool _disabled;

    void Start()
    {
        float storedSpeed = speed;
        PauseHandler.Instance.AddPauseEvent(() =>{
            this.speed = 0;
        });

        PauseHandler.Instance.AddUnpauseEvent(() =>{
            this.speed = storedSpeed;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(_disabled) return;

        transform.Rotate(rotator*speed*Time.deltaTime);
    }
}
