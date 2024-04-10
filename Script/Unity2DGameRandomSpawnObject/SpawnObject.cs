using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("生成物件/SpawnObject")]
    public GameObject SpawnObj;

    [Header("生成数量/SpawnNum")]
    public int MinSpawnCount;
    public int MaxSpawnCount;
    int SpawnCount;
    public int Spawncul = 0;

    [Header("生成范围/SpawnArea")]
    public BoxCollider2D boxcollider2d;
    private void Awake()
    {
        boxcollider2d = GetComponent<BoxCollider2D>();
        SpawnCount = Random.Range(MinSpawnCount, MaxSpawnCount);
    }
    private void Start()
    {
        
        if (boxcollider2d)
        {
            while (Spawncul < SpawnCount)
            {
                Spawncul += 1;
                Debug.Log(boxcollider2d.bounds.max);
                float BoundPositionXLength = boxcollider2d.bounds.max.x;
                float BoundPositionYLength = boxcollider2d.bounds.max.y;
                Spawn(BoundPositionXLength, BoundPositionYLength);
            }

        }
    }
    void Spawn(float postionX, float PositonY)
    {
        float X = Random.RandomRange(0 - postionX, postionX);
        float Y = Random.RandomRange(0 - PositonY, PositonY);
        Vector3 spawnvector = new Vector3(X, Y, 0);
        SpawnObj.transform.position = spawnvector;
        if(SpawnObj != null)
        {
            Instantiate<GameObject>(SpawnObj, SpawnObj.transform);
            

        }
        Debug.Log(X);
        Debug.Log(Y);

    }

}
