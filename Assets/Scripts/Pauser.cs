using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pauser : MonoBehaviour
{

    public bool paused;
    public bool disabled;

    public Vector3 stored;
    public GameObject pausedUI;
    GameObject ghost;

    List<Freezer> objects = new List<Freezer>();

    // Start is called before the first frame update
    void Start()
    {
        objects = GameObject.FindObjectsOfType<Freezer>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            paused = !paused;
            pausedUI.SetActive(paused);
            if(paused){
                stored = transform.position;
                CreateGhost();
            }else{
                transform.position = stored;
                Destroy(ghost);
            }

            foreach (Freezer freeze in objects)
            {
                freeze.Freeze = paused;
            }
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
}
