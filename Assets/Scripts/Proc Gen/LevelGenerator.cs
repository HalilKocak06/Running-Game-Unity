using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] CameraController cameraController; //Script objesi
    [SerializeField] GameObject chunkPrefab; // Bu GameObject bir class gibi düşün ve ayrıca Hangi prefab'ı instatian edeceğini gösterir.
    [SerializeField] int startingChunksAmount = 12; //oyunun başında kaç adet ile başlayacağını gösterir.
    [SerializeField] Transform chunkParent; //
    [SerializeField] float chunkLength = 10f; //her yol parçasının uzunluğu
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;

    List<GameObject> chunks = new List<GameObject>();

    void Start()
    {
        SpawnStartingChunks();
    }

    private void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();

        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ); //XveY sabit Z ileri kayıyor.
        GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunk);
    }

    private float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;

        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {

            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }

    void Update()
    {
        MoveChunks();
    }

    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        moveSpeed += speedAmount;

        if (moveSpeed < minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;
        }

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedAmount);

        cameraController.ChangeCameraFOV(speedAmount);
    }

    void MoveChunks()
    {
        for(int i=0; i<chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunks[i].transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            if(chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}
