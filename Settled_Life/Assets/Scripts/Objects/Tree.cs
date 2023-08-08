using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Tree : MonoBehaviour
{
    private ResourcesManager resources;
    private WarSceneResources warResources;
    private Animator anim;
    public int maxHealth;
    public int health;
    public GameObject woodBreakingFX;
    public GameObject woodImage;
    public int growSpeed;
    private void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            resources = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourcesManager>();
        }
        else
        {
            warResources = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<WarSceneResources>();
        }
    }
    public void TakeDamage()
    {
        health -= 1;
        Instantiate(woodBreakingFX, transform.position, Quaternion.identity);
        anim.SetTrigger("TakeDamage");
        //Objenin bulunduðu yerin ekrandaki konumunu alýp orada bir aðaç resmi oluþturuyor.
        Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
        GameObject woodImg = Instantiate(woodImage, camPos, Quaternion.identity, resources.transform);
        woodImg.GetComponent<WoodImage>().target = resources.transform.GetChild(0).transform.GetChild(0).GetComponent<RectTransform>();

        PlayerPrefs.SetInt("WoodCount", PlayerPrefs.GetInt("WoodCount") + 1);

        if (health <= 0)
        {
            anim.SetTrigger("Death1");
            StartCoroutine(GrowUp());
            health = maxHealth;
        }
    }
    public void TakeDamageOnWarScene()
    {
        health -= 1;
        Instantiate(woodBreakingFX, transform.position, Quaternion.identity);
        anim.SetTrigger("TakeDamage");
        //Objenin bulunduðu yerin ekrandaki konumunu alýp orada bir aðaç resmi oluþturuyor.
        Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
        GameObject woodImg = Instantiate(woodImage, camPos, Quaternion.identity, warResources.transform);
        woodImg.GetComponent<WoodImage>().target = warResources.transform.GetChild(0).transform.GetChild(0).GetComponent<RectTransform>();

        PlayerPrefs.SetInt("WarSceneWoodCount", PlayerPrefs.GetInt("WarSceneWoodCount") + 1);

        if (health <= 0)
        {
            anim.SetTrigger("Death1");
            StartCoroutine(GrowUp());
            health = maxHealth;
        }
    }
    private void Grow()
    {
        anim.SetBool("Grow", true);
    }
    IEnumerator GrowUp()
    {
        yield return new WaitForSeconds(growSpeed);
        anim.SetTrigger("Grow");
        StopAllCoroutines();
    }
}
