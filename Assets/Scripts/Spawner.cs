using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private Transform leftTransform, rightTransform;

    private GameObject spawnedEnemy;

    void Start()
    {
        this.StartCoroutine(this.SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            var index = Random.Range(0, this.enemies.Length);
            var isLeft = Random.Range(0, 2) == 0;
            this.spawnedEnemy = Instantiate(this.enemies[index]);

            if (isLeft)
            {
                this.spawnedEnemy.transform.position = this.leftTransform.position;
                this.spawnedEnemy.GetComponent<Enemy>().setSpeed(Random.Range(4, 10));
            }
            else
            {
                this.spawnedEnemy.transform.position = this.rightTransform.position;
                this.spawnedEnemy.GetComponent<Enemy>().setSpeed(-Random.Range(4, 10));
                this.spawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }

        }
    }
}
