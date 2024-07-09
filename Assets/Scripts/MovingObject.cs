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
        //inicializamos nuestras variables
        startPosition = transform.position;
        finishPosition = startPosition + moveOffset;
        //asi hacemos que el primer movimiento sea hacia el final de la trayectoria
        targetPosition = finishPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //guardamos la posición actual del objeto
        Vector2 currentPosition = transform.position;
        //calculamos la nueva posicion siguiendo el vector de movimiento
        currentPosition += (targetPosition - currentPosition).normalized * Time.deltaTime;
        //aplicamos la traslación
        transform.position = currentPosition;


        //si esta muy cerca del final de la trayectoria hacemos que vaya hacia el principio
        if((currentPosition - finishPosition).magnitude < 0.01f)
        {
            targetPosition = startPosition;
        }
        //si esta muy cerca del inicio de la trayectoria hacemos que vaya hacia el final
        else if ((currentPosition - startPosition).magnitude < 0.01f)
        {
            targetPosition = finishPosition;
        }
    }
}
