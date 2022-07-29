using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectScript : MonoBehaviour
{

    Vector3 startPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (period == 0)
        {
            return;
        }
        float cyrcle = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cyrcle * tau);
        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startPosition + offset;

    }
}
