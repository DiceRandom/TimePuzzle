using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PauseHandler.Instance.AddPauseEvent(() =>{
            Debug.Log("Pause");
        });

        PauseHandler.Instance.AddUnpauseEvent(() =>{
            Debug.Log("Unpause");
        });
    }
}
