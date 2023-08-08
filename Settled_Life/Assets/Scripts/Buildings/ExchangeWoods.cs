using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ExchangeWoods : MonoBehaviour
{
    public Animator uiAnimator;
    public TextMeshProUGUI offer1WoodText;
    public TextMeshProUGUI offer2WoodText;
    public TextMeshProUGUI offer1GoldText;
    public TextMeshProUGUI offer2GoldText;

    private int offer1WoodCount;
    private int offer2WoodCount;

    private int offer1GoldCount;
    private int offer2GoldCount;

    private bool isActive = false;
    private void Start()
    {
        isActive = true;
        CalculateAmounts();
    }
    private void Update()
    {
        if (isActive)
        {
            Texts();
        }
    }
    private void Texts()
    {
        offer1WoodText.text = offer1WoodCount.ToString();
        offer1GoldText.text = offer1GoldCount.ToString();

        offer2WoodText.text = offer2WoodCount.ToString();
        offer2GoldText.text = offer2GoldCount.ToString();
    }
    private void CalculateAmounts()
    {
        offer1WoodCount = Random.Range(50, 250);
        offer2WoodCount = offer1WoodCount * 2;

        offer1GoldCount = offer1WoodCount / 4;
        offer2GoldCount = offer2WoodCount / 3;
    }
    public void Offer1()
    {
        if (PlayerPrefs.GetInt("WoodCount") >= offer1WoodCount)
        {
            PlayerPrefs.SetInt("WoodCount", PlayerPrefs.GetInt("WoodCount") - offer1WoodCount);
            PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") + offer1GoldCount);
            uiAnimator.SetBool("isOpen", false);
            isActive = false;
            StartCoroutine(SettingActive());
        }
    }
    public void Offer2()
    {
        if (PlayerPrefs.GetInt("WoodCount") >= offer2WoodCount)
        {
            PlayerPrefs.SetInt("WoodCount", PlayerPrefs.GetInt("WoodCount") - offer2WoodCount);
            PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") + offer2GoldCount);
            uiAnimator.SetBool("isOpen", false);
            isActive = false;
            StartCoroutine(SettingActive());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiAnimator.SetBool("isOpen", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiAnimator.SetBool("isOpen", false);
        }
    }
    private IEnumerator SettingActive()
    {
        yield return new WaitForSeconds(3f);
        CalculateAmounts();
        isActive = true;
    }
}
