using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    private Animator anim;
    private bool isOpen;
    [Header("Vibration Variables")]
    public Sprite vibrationOnImage;
    public Sprite vibrationOffImage;
    public Image vibrationIcon;
    private bool isVibrationClose;

    [Header("Sound Variables")]
    public Sprite soundOnImage;
    public Sprite soundOffImage;
    public Image soundIcon;
    private bool isSoundClose;

    [Header("Information Screen Variables")]
    public GameObject InformationScreen;
    public Animator infoScreenAnim;
    private bool isInfoScreenClose;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("isOpen", isOpen);
        
    }
    public void OpenSettingsButtons()
    {
        isOpen = !isOpen;
    }
    #region Vibration Settings
    public void VibrationSettingButton()
    {
        isVibrationClose = !isVibrationClose;
        ChangeVibrationIcon();
    }
    private void ChangeVibrationIcon()
    {
        if (isVibrationClose)
        {
            vibrationIcon.sprite = vibrationOffImage;
        }
        else
        {
            vibrationIcon.sprite = vibrationOnImage;
        }
    }
    #endregion
    #region Sound Settings
    public void SoundSettingButton()
    {
        isSoundClose = !isSoundClose;
        ChangeSoundIcon();
    }
    private void ChangeSoundIcon()
    {
        if (isSoundClose)
        {
            soundIcon.sprite = soundOffImage;
        }
        else
        {
            soundIcon.sprite = soundOnImage;
        }
    }
    #endregion
    #region Information Screen Settings
    public void InformationScreenOpen()
    {
        InformationScreen.SetActive(true);
        infoScreenAnim.SetBool("isOpen", true);
    }
    public void InformationScreenClose()
    {
        infoScreenAnim.SetBool("isOpen", false);
    }
    #endregion
}
