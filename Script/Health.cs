using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("�ͩR��")]
    public float CharacterHealth = 100;
    public Image HealthImage;
    [Header("�ͩR�ȴ�ֳt��")]
    public float MinusHealthSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       CharacterHealth -= MinusHealthSpeed*Time.deltaTime;
       HealthImage.fillAmount = CharacterHealth / 100;
    }
}
