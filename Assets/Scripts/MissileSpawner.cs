using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missile;
    public Transform player;
    public float spawnInterval = 3f;
    public float spawnDistance = 12f;
    private float spawnTimer;
    private float survivalTimer;
    private int missilesPerWave = 1;

    void Update()
    {
        survivalTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        if (survivalTimer >= 10f)
        {
            missilesPerWave++;
            survivalTimer = 0f;
        }

        if (spawnTimer >= spawnInterval)
        {
            for (int i = 0; i < missilesPerWave; i++)
            {
                Vector3 spawnPosition = player.position + Random.onUnitSphere * spawnDistance;
                spawnPosition.y = player.position.y;
                Instantiate(missile, spawnPosition, Quaternion.identity);
            }
            spawnTimer = 0f;
        }
    }
}