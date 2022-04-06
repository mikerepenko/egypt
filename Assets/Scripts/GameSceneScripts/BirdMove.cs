using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    [HideInInspector]
    public Vector3 direction;

    float speed;
    Vector3 startPos;

    private void Start()
    {
        speed = 2f;
        startPos = transform.localPosition;
    }

    private void Update()
    {
        if(Vector3.Distance(startPos, transform.localPosition) > 72f)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}