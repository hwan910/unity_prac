using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    private readonly float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };

    [SerializeField]
    private float spawnInterval = 1.5f;

    [SerializeField]
    private GameObject[] enemies;


    [SerializeField]
    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoutine();
    }

    public void StopEnemyRoutine()
    {
        StopCoroutine(nameof(EnemyRoutine));
    }


    void StartEnemyRoutine()
    {
        StartCoroutine(nameof(EnemyRoutine));
    }
    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);


        float moveSpeed = 5f;
        int enemyIndex = 0;
        int spawnCount = 0;


        while (true)
        {
            foreach (float posX in arrPosX)
            {
                SpawnEnemy(posX, enemyIndex, moveSpeed);
            }

            spawnCount++;
            if (spawnCount % 5 == 0)
            {
                enemyIndex += 1;
                moveSpeed += 2;

            };
            if (enemyIndex >= enemies.Length)
            {
                SpawnBoss();
                enemyIndex = 0;
                moveSpeed = 5f;
            }


            yield return new WaitForSeconds(spawnInterval);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy(float posX, int index, float moveSpeed)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.x);

        if (Random.Range(0, 5) == 0)
        {
            index += 1;
        }

        if (index >= enemies.Length)
        {
            index = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeend(moveSpeed);




    }


    void SpawnBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
