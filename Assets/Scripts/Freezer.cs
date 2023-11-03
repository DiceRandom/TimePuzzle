using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Freezer : MonoBehaviour
{
    public UnityEvent onFreeze;
    public UnityEvent onUnfreeze;
    

    public bool Freeze
    {
        get { return _Freeze; }
        set
        {
            _Freeze = value;
            if(Freeze){
                onFreeze.Invoke();
            }else{
                onUnfreeze.Invoke();
            }
        }
    }

    private bool _Freeze;
}
