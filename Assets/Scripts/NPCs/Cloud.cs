using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : NPCMovement
{
    [Header("Cloud Sprites")]
    public Sprite[] sprites;


    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Move();
    }
}
