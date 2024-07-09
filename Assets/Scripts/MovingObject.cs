using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private Vector2 moveOffset = Vector2.zero;
    private Vector2 startPosition = Vector2.zero;
    private Vector2 targetPosition = Vector2.zero;
    private Vector2 finishPosition = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        finishPosition = startPosition + moveOffset;
        targetPosition = finishPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = transform.position;
        currentPosition += (targetPosition - currentPosition).normalized * Time.deltaTime;
        transform.position = currentPosition;
        if((currentPosition - finishPosition).magnitude < 0.01f)
        {
            targetPosition = startPosition;
        } else if ((currentPosition - startPosition).magnitude < 0.01f)
        {
            targetPosition = finishPosition;
        }
    }
}
