using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1C : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float rotSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * Input.GetAxis("Vertical") * speed;
        transform.Rotate(0f, rotSpeed * Input.GetAxis("Horizontal"), 0f);
        
    }
}