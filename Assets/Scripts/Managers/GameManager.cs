using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float secondsBetweenBullets;
    [SerializeField] private GameObject bulletPrefab;

    private static GameManager instance;
    public static GameManager Instance => instance;

    private bool gameStarted;
    public bool GameStarted => gameStarted;
    private float timePlaying = 0.0f;

    public void OnTogglePause(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            gameStarted = !gameStarted;
            if (!gameStarted)
            {
                StopAllCoroutines();
            }
            else
            {
                StartCoroutine(SpawnBullets());
            }
            UIManager.Instance.TogglePauseMenu(!gameStarted);
        }
    }

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

