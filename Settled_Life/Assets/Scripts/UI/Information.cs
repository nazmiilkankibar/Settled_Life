using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    public void SetClose()
    {
        transform.gameObject.SetActive(false);
    }
    public void FacebookButton()
    {
        Application.OpenURL("https://www.facebook.com/");
    }
    public void InstagramButton()
    {
        Application.OpenURL("https://www.instagram.com/");
    }
    public void PlayStoreButton()
    {
        Application.OpenURL("https://play.google.com/");
    }
    public void WebsiteButton()
    {
        Application.OpenURL("https://www.google.com/");
    }
}
