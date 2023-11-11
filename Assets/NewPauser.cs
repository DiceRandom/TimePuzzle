using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseHandler : MonoBehaviour
{

    public Vector3 stored;
    public GameObject pausedUI;
    public bool paused;
    GameObject ghost;


    [SerializeField]
    private UnityEvent unpauseEvent;
    
    [SerializeField]
    private UnityEvent pauseEvent;


    private static PauseHandler _instance;
    public static PauseHandler Instance{
        get{
            if(_instance == null){
                Debug.LogError("Pauser Null");
            }
            return _instance;
        }
    }

    private void Awake() {
        _instance = this;
    }

    private void Update() {
        if(Input.GetButtonDown("Fire1")){
            paused = !paused;
            pausedUI.SetActive(paused);
            if(paused){
                stored = transform.position;
                CreateGhost();
                // pause
                pauseEvent.Invoke();

            }else{
                transform.position = stored;
                Destroy(ghost);
                // unpause
                unpauseEvent.Invoke();
            }
        }
    }

    
    public void AddPauseEvent(UnityAction ue){
        pauseEvent.AddListener(ue);
        Debug.Log("pause event added");
    }

    public void AddUnpauseEvent(UnityAction ue){
        unpauseEvent.AddListener(ue);
        Debug.Log("unpause event added");
    }


    void CreateGhost(){
        ghost = new GameObject("Ghost");
        ghost.transform.position = stored;
        ghost.transform.localScale = transform.localScale;
        ghost.AddComponent<SpriteRenderer>();
        ghost.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        ghost.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.30f);
    }
}
