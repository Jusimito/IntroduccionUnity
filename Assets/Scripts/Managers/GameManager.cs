using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float secondsBetweenBullets;
    [SerializeField] private GameObject bulletPrefab;

    private static GameManager instance;
    public static GameManager Instance => instance;

    private bool gameStarted;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);
            instance = null;
        }
        instance = this;
    }

    private void Start()
    {
        gameStarted = true;
        StartCoroutine(SpawnBullets());
        PlayerController.DieEvent.AddListener(() => gameStarted = false);
    }

    private IEnumerator SpawnBullets()
    {
        while (gameStarted)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenBullets);
        }
    }

}

