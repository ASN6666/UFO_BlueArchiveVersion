using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("玩家物件")]
    public GameObject Player;

    [Header("相对位移")]
    public Vector3 offset;

    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
