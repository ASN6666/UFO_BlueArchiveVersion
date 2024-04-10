using Unity.VisualScripting;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [Header("PlayerCharacter/���a")]
    public GameObject PlayerCharacter;

    [SerializeField]
    GameObject ObjTarget;


    [Header("�l���t��")]
    public float Speed = 20;

    private bool bMoveToTarget;
    private void Awake()
    {
        ObjTarget = gameObject.transform.parent.gameObject;
    }
    private void Update()
    {
        if (bMoveToTarget)
        {
            ObjTarget.transform.position = Vector2.MoveTowards(ObjTarget.transform.position, PlayerCharacter.transform.position,Speed * Time.deltaTime);

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger!!!");
            PlayerCharacter = other.gameObject;
            bMoveToTarget = true;

        }
    }
   

}
