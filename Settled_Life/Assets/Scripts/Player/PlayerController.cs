using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    //Components
    private MovementJoystick joystick;
    [HideInInspector] public Animator anim;
    private EvilGate evilGate;
    private Rigidbody rb;


    [Header("Movement")]
    private float inputX;
    private float inputZ;
    public float speed;
    public float turnSpeed;

    [Header("Health")]
    public Image healthBar;
    public float maxHealth;
    public float health;
    public TextMeshProUGUI healthText;
    public bool isDead;
    [Header("GameObjects")]
    public GameObject bloodFX;
    private GameObject deathScreen;
    public GameObject smokePuff;
    private Transform spawnPos;
    private TextMeshProUGUI lostResourcesText;
    public Transform footPos;
    public bool isWin;
    private void Start()
    {
        //NavMesh.RemoveAllNavMeshData();
        rb = GetComponent<Rigidbody>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MovementJoystick>();
        anim = GetComponent<Animator>();
        
        maxHealth = PlayerPrefs.GetFloat("PlayerHealth");
        health = maxHealth;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            deathScreen = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(4).gameObject;
            lostResourcesText = deathScreen.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            spawnPos = GameObject.FindGameObjectWithTag("PlayerSpawnPos").transform;
            evilGate = GameObject.FindGameObjectWithTag("EvilGate").GetComponent<EvilGate>();
            if (PlayerPrefs.GetInt("DeathScreen") == 1)
            {
                OpenDeathSettings();
                PlayerPrefs.SetInt("DeathScreen", 0);
            }
        }
    }
    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }
        else if (isWin)
        {
            Win();
        }
        else
        {
            Movement();
            HealthBar();
            rb.velocity = Vector3.zero;
        }
    }
    private void Movement()
    {
        inputX = joystick.joystickVector.x;
        inputZ = joystick.joystickVector.y;

        Vector3 movement = new Vector3(inputX, 0, inputZ);
        float magnitude = Mathf.Clamp01(movement.magnitude) * speed;
        movement.Normalize();
        transform.Translate(movement * magnitude * Time.deltaTime, Space.World);
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);

            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(bloodFX, transform.position, Quaternion.identity, transform);
        if (health <= 0)
        {
            isDead = true;
            health = 0;
            HealthBar();
            GetComponent<CapsuleCollider>().enabled = false;
            anim.SetBool("AttackEnemy", false);
            anim.SetBool("Attack", false);
            anim.SetBool("isRunning", false);
            anim.SetTrigger("Death");
            
            Invoke("Death", 3);
        }
    }
    void HealthBar()
    {
        healthBar.fillAmount = (health / maxHealth);
        healthText.text = health.ToString();
    }
    public void SmokePuff()
    {
        Instantiate(smokePuff, footPos.position, footPos.rotation);
    }
    public void Death()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            isDead = false;
            health = maxHealth;
            transform.position = spawnPos.position;
            rb.velocity = Vector3.zero;
            GetComponent<CapsuleCollider>().enabled = true;
            anim.SetBool("isRunning", false);
            anim.SetBool("Attack", false);
            anim.SetBool("AttackEnemy", false);
            anim.SetBool("isWin", false);
            if (evilGate != null)
            {
                ClearEnemies();
            }
            OpenDeathSettings();
        }
        else
        {
            PlayerPrefs.SetInt("DeathScreen", 1);
            SceneManager.LoadScene(0);
        }
    }
    public void Win()
    {
        anim.SetBool("isWin", true);
        transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }
    public void OpenDeathSettings()
    {
        float lostGold = (float)PlayerPrefs.GetInt("GoldCount") * .25f;
        PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") - (int)lostGold);

        float lostWood = (float)PlayerPrefs.GetInt("WoodCount") * .25f;
        PlayerPrefs.SetInt("WoodCount", PlayerPrefs.GetInt("WoodCount") - (int)lostWood);
        for (int i = 0; i < deathScreen.transform.childCount; i++)
        {
            deathScreen.transform.GetChild(i).transform.gameObject.SetActive(true);
        }
        lostResourcesText.text = "You died and you lost " + (int)lostGold + " gold and " + (int)lostWood + " wood";
        deathScreen.SetActive(true);
    }
    private void ClearEnemies()
    {
        for (int i = 0; i < evilGate.spawnedEnemies.Count; i++)
        {
            GameObject enemyObj = evilGate.spawnedEnemies[i];
            Destroy(enemyObj);
        }
        evilGate.spawnedEnemies.Clear();
    }
}
