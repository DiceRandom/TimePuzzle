using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;



public class PlayerGraphicHandler : MonoBehaviour
{

    Movement pMovement;

    public Sprite current;

    public float runSpeed;

    public Sprite[] sprites = new Sprite[4];

    // Start is called before the first frame update
    void Start()
    {
        pMovement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().flipX = !pMovement.direction;
        GetComponent<SpriteRenderer>().sprite = sprites[(int)pMovement.currentState];
    }
}

