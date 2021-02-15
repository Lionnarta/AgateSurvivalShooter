using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    //public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    [SerializeField]
    EnemyFactory factory;
    IFactory Factory { get { return factory as IFactory;  } }

    void Start()
    {
        // Repeat spawn game object enemy
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int SpawnPointIndex = Random.Range(0, spawnPoints.Length);
        //instantiate(enemy, spawnpoints[spawnpointindex].position, spawnpoints[spawnpointindex].rotation);
        int spawnEnemy = Random.Range(0, 3);

        Factory.FactoryMethod(spawnEnemy, spawnPoints[SpawnPointIndex].position, spawnPoints[SpawnPointIndex].rotation);
    }
}
