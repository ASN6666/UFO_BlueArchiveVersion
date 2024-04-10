using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class PlayeController : MonoBehaviour
{
    [Header("水平方向")]
    public float MoveX;

    [Header("垂直方向")]
    public float MoveY;
    [Header("推力")]
    public float Push;
    Rigidbody2D rb2d;

    [Header("分数文字")]
    public Text CountText;

    [Header("通关文字")]
    public GameObject SpawnAreaPref;
    public Text Wintext;
    [SerializeReference]
    int score = 0;

    [Header("下一關 關卡名稱")]
    public string LevelName;

    [Header("技能冷卻時間")]
    public float CoolDownTimer;
    public float AbilityDuration;
    public Text AbilityCoolDownTimeText;
    private bool bCoolDownComplate = true;

    private bool bUseAbility;

    [Header("舌頭")]
    public GameObject Tongue;
    private void Awake()
    {   
        AbilityCoolDownTimeText.text = CoolDownTimer.ToString();
        Tongue = gameObject.transform.GetChild(0).gameObject;

    }
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Wintext.text = "";
        SetScoreText();
    }
    private void Update()
    {   
        //使用技能
        if(Input.GetKeyDown(KeyCode.Space))
        {   
            if(bCoolDownComplate)
            {
                bUseAbility = true;
            }
        }
        UseAbility();
        
    }
    private void UseAbility()
    {   
        if (bUseAbility) //當啟用 技能 為真
        {
            Tongue.SetActive(true);
            Tongue.GetComponent<Rotator>().On = true;
            bCoolDownComplate = false;
            CoolDownTimer -= 1 * Time.deltaTime;
            AbilityCoolDownTimeText.text = CoolDownTimer.ToString();
            if (CoolDownTimer > 5) //當技能大於 技能時間時 啟用技能
            {
                FindPickUPGameObject(8f);
            }
            else if (CoolDownTimer <= 5) // 當技能時間結束時 還原原本狀態
            {
                FindPickUPGameObject(2f);
                Tongue.SetActive(false);
            }
            else if (CoolDownTimer <= 0) //當冷卻結束的時候 重置
            {   
                CoolDownTimer = 10;
                bCoolDownComplate = true;
                bUseAbility = false;
                AbilityCoolDownTimeText.text = CoolDownTimer.ToString();
                Tongue.SetActive(false);
                Tongue.GetComponent<Rotator>().On = false;
            }
        }
    }
    private void FindPickUPGameObject(float ColliRadius)
    {
        GameObject[] PickUpobj;
        PickUpobj = GameObject.FindGameObjectsWithTag("PickUp");
        foreach (GameObject p in PickUpobj)
        {
            p.transform.GetChild(0).GetComponent<CircleCollider2D>().radius = ColliRadius;

        }
    }
    private void FixedUpdate()
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(MoveX, MoveY);
        rb2d.AddForce(movement * Push);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            SetScoreText();
            float CharacterHealthRef = this.gameObject.GetComponent<Health>().CharacterHealth;
            this.gameObject.GetComponent<Health>().CharacterHealth += Mathf.Clamp(1,0, CharacterHealthRef);
        }
    }
    void SetScoreText()
    {
        CountText.text = "目前分数" + score.ToString();
        int TargetScore = SpawnAreaPref.GetComponent<SpawnObject>().Spawncul;
        Debug.Log("Score :"+score);
        Debug.Log("TargetScore : "+TargetScore);
        if(TargetScore > 0)
        {
            if (score >= TargetScore)
            {
                Wintext.text = "你赢了";
                Invoke("LoadScene", 2.5f);

            }
        }
        
    }
    void LoadScene()
    {
        SceneManager.LoadScene(LevelName);
    }

}
