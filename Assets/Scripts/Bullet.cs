using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletConfig config;

    private Vector2 direction;
    private Vector2 currentPosition;

    private PlayerController playerController;


    private void Start()
    {
        direction = Vector2.right;
        currentPosition = transform.position;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        StartCoroutine(DestroyAfterSeconds());
    }

    private void Update()
    {
        if (GameManager.Instance.GameStarted)
        {
            Move();
        }
    }

    private void FixedUpdate()
    {
        if (playerController != null)
        {
            if (Vector2.Distance(currentPosition, playerController.transform.position) <= config.CollisionThreshold)
            {
                DoDamage();
            }
        }
    }

    private IEnumerator DestroyAfterSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(config.Lifetime);
            if (GameManager.Instance.GameStarted)
            {
                Die();
            }
        }
    }


    private void Die()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private void Move()
    {
        currentPosition += direction * config.Speed * Time.deltaTime;
        transform.position = currentPosition;
    }

    private void DoDamage()
    {
        playerController.ReceiveDamage(config.Damage);
        Die();
    }
}

