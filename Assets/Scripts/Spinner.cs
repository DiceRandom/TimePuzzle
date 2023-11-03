using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    public Vector3 rotator;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_paused) return;
        transform.Rotate(rotator*speed*Time.deltaTime);
    }

    public void Disable(){
        speed = 0;
    }



    public bool Paused
    {
        get { return _paused; }
        set
        {_paused = value; }
    }

    private bool _paused;
}
