using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab; // Bu GameObject bir class gibi düşün ve ayrıca Hangi prefab'ı instatian edeceğini gösterir.
    [SerializeField] int startingChunksAmount = 12; //oyunun başında kaç adet ile başlayacağını gösterir.
    [SerializeField] Transform chunkParent; //
    [SerializeField] float chunkLength = 10f; //her yol parçasının uzunluğu
    [SerializeField] float moveSpeed = 8f;

    GameObject[] chunks = new GameObject[12];

    void Start()
    {
        SpawnChunks();
    }

    private void SpawnChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            float spawnPositionZ = CalculateSpawnPositionZ(i);

            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ); //XveY sabit Z ileri kayıyor.
            GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

            chunks[i] = newChunk;
        }
    }

    private float CalculateSpawnPositionZ(int i)
    {
        float spawnPositionZ;

        if (i == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {

            spawnPositionZ = transform.position.z + (i * chunkLength);
        }

        return spawnPositionZ;
    }

    void Update()
    {
        MoveChunks();
    }

    void MoveChunks()
    {
        for(int i=0; i<chunks.Length; i++)
        {
            chunks[i].transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));
        }
    }
}
