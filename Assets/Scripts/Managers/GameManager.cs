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
    private float timePlaying = 0.0f;

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

    private void FixedUpdate()
    {
        if (gameStarted)
        {
            timePlaying += Time.fixedDeltaTime;
            UIManager.Instance.UpdateTimeCounter(timePlaying);
        }
    }

    private IEnumerator SpawnBullets()
    {
        while (gameStarted)
        {
            yield return new WaitForSeconds(secondsBetweenBullets);
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }

}

