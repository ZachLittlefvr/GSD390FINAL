using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemySpawning : MonoBehaviour
{
    public Rigidbody enemy;
    private float SpawnX;
    private float SpawnZ;
    public Transform player;
    private int spawnTimer;
    private int spawnFaster;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = 0;
        spawnFaster = 2;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer = spawnTimer + 1;
        if((500 - spawnFaster) < 0)
        {
            SceneManager.LoadScene("GameWin");
        }
        if(spawnTimer > 500 - spawnFaster)
        {
        int Side = Random.Range(1,2);
        if(Side == 1)
        {
            SpawnX = Random.Range(player.position.x - 50f,player.position.x - 10f);
        }
        else
        {
            SpawnX = Random.Range(player.position.x + 10f,player.position.x + 50f);
        }
        Side = Random.Range(1,2);
        if(Side == 1)
        {
            SpawnZ = Random.Range(player.position.z - 50f,player.position.z - 10f);
        }
        else
        {
            SpawnZ = Random.Range(player.position.z + 10f,player.position.z + 50f);
        }
        Vector3 SpawnLocation = new Vector3(SpawnX, 1, SpawnZ);

        Rigidbody spawned = Instantiate(enemy, SpawnLocation, transform.rotation);
        spawnTimer = 0;
        spawnFaster = spawnFaster + 5;
        }
    }
}
