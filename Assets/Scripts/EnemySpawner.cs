using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Text spawnedEnemiesText;
    [SerializeField] AudioClip spawnedEnemySFX;
    int score = 0;

    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnedEnemiesText.text = score.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        yield return new WaitForSeconds(secondsBetweenSpawns);
        while (true)
        {
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            GameObject gameObjectEnemy = Instantiate(enemyPrefab.gameObject, transform.position, Quaternion.identity) as GameObject;
            gameObjectEnemy.transform.parent = transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        score++;
        spawnedEnemiesText.text = score.ToString();
    }
}
