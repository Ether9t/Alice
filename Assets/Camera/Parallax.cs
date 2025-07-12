using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform Cam;
    public float MoveRate;
    private float StartPointX;
    
    // Start is called before the first frame update
    void Start()
    {
        StartPointX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(StartPointX + Cam.position.x * MoveRate, transform.position.y);
    }
}
