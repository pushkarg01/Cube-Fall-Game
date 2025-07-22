using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformSpawnner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject spikeplatformPrefab;
    [SerializeField] GameObject[] movingplatformPrefab;
    [SerializeField] GameObject breakableplatformPrefab;

    public float platformSpawnTimer = 2f;
    private float currentplatformSpawnTimer;

    private int platformSpawnCount;

    private float minX=-2, maxX=2;

    void Start()
    {
        currentplatformSpawnTimer = platformSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Spawnplatform();
    }

    void Spawnplatform()
    {
        currentplatformSpawnTimer += Time.deltaTime;

        if(currentplatformSpawnTimer >=platformSpawnTimer)
        {
            platformSpawnCount++;
            Vector3 temp=transform.position;
            temp.x= Random.Range(minX, maxX);

            GameObject newplatform = null;

            if (platformSpawnCount < 2)
            {
                newplatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if (platformSpawnCount == 2) 
            {
                if (Random.Range(0, 2) == 1) 
                {
                    newplatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newplatform = Instantiate(movingplatformPrefab[Random.Range(0, movingplatformPrefab.Length)], temp, Quaternion.identity);

                }

            }
            else if (platformSpawnCount == 3)
            {
                if (Random.Range(0, 2) == 1)
                {
                    newplatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newplatform = Instantiate(spikeplatformPrefab, temp, Quaternion.identity);

                }
            }
            else if (platformSpawnCount == 4)
            {
                if (Random.Range(0, 2) == 1)
                {
                    newplatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newplatform = Instantiate(breakableplatformPrefab, temp, Quaternion.identity);

                }

                platformSpawnCount = 0;
            }

            if (newplatform)
            {
                newplatform.transform.parent = transform;
            }
            currentplatformSpawnTimer = 0f;

        }
    }
}
