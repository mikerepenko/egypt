using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGenerate : MonoBehaviour
{
    [SerializeField] GameObject BirdPrefab;
    [SerializeField] bool right;

    float currentTime;
    float startTime;

    void Start()
    {
        currentTime = 0f;
        startTime = 10f;
    }

    void Update()
    {
        if(currentTime < startTime)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            GameObject newBird = Instantiate(BirdPrefab, transform);
            newBird.transform.localPosition = new Vector3(0f, Random.Range(16f, -16f));
            if (right)
            {
                newBird.GetComponent<BirdMove>().direction = Vector3.right;
                newBird.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                newBird.GetComponent<BirdMove>().direction = Vector3.left;
            }

            currentTime = 0f;
        }
    }
}