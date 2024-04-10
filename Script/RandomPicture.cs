using UnityEngine;
using UnityEngine.UI;

public class RandomPicture : MonoBehaviour
{
    [Header("³õ´º¹Ï¤ù")]   
    public Sprite[] Spriteimage;
    void Start()
    {
        Sprite setImage;
        setImage = Spriteimage[Random.RandomRange(0, Spriteimage.Length)] ;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = setImage;
        
    }
}
