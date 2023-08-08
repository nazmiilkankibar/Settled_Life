using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MovementJoystick : MonoBehaviour
{
    //, IDragHandler, IPointerDownHandler, IPointerUpHandler
    //private Image imgJoystickBG;
    //private Image imgJoystick;

    //private Vector2 posInput;

    //private void Start()
    //{
    //    imgJoystickBG = transform.GetComponent<Image>();
    //    imgJoystick = transform.GetChild(0).GetComponent<Image>();
    //}
    //public void OnDrag(PointerEventData eventData)
    //{
    //    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
    //        imgJoystickBG.rectTransform,
    //        eventData.position,
    //        eventData.pressEventCamera,
    //        out posInput))
    //    {
    //        posInput.x = posInput.x / (imgJoystickBG.rectTransform.sizeDelta.x);
    //        posInput.y = posInput.y / (imgJoystickBG.rectTransform.sizeDelta.y);
    //        Debug.Log(posInput);

    //        if (posInput.magnitude > 1)
    //        {
    //            posInput = posInput.normalized;
    //        }

    //        imgJoystick.rectTransform.anchoredPosition = new Vector2(
    //            posInput.x * (imgJoystickBG.rectTransform.sizeDelta.x / 2),
    //            posInput.y * (imgJoystickBG.rectTransform.sizeDelta.y / 2)
    //            );
    //    }
    //}
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    OnDrag(eventData);
    //}
    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    posInput = Vector2.zero;
    //    imgJoystick.rectTransform.anchoredPosition = Vector2.zero;
    //}
    //public float InputHorizontal()
    //{
    //    if (posInput.x != 0)
    //    {
    //        return posInput.x;
    //    }
    //    else
    //    {
    //        return Input.GetAxis("Horizontal");
    //    }
    //}
    //public float InputVertical()
    //{
    //    if (posInput.y != 0)
    //    {
    //        return posInput.y;
    //    }
    //    else
    //    {
    //        return Input.GetAxis("Vertical");
    //    }
    //}



    public GameObject joystick;
    public GameObject joystickBG;
    public Vector3 joystickVector;

    private Vector3 touchPos;
    private Vector3 originalPos;
    private float radius;
    private void Start()
    {
        originalPos = joystickBG.transform.position;
        radius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 2;
    }
    public void PointerDown()
    {
        joystick.SetActive(true);
        joystickBG.SetActive(true);
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        touchPos = Input.mousePosition;
    }
    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 dragPos = pointerEventData.position;
        joystickVector = (dragPos - touchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, touchPos);

        if (joystickDist < radius)
        {
            joystick.transform.position = touchPos + joystickVector * joystickDist;
        }
        else
        {
            joystick.transform.position = touchPos + joystickVector * radius;
        }
    }
    public void PointerUp()
    {
        joystickVector = Vector3.zero;
        joystick.transform.position = originalPos;
        joystickBG.transform.position = originalPos;
        joystick.SetActive(false);
        joystickBG.SetActive(false);
    }
}
