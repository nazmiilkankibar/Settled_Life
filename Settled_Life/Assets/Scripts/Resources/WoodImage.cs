using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodImage : MonoBehaviour
{
    public RectTransform woodUITransform;
    public RectTransform target;
    private void Update()
    {
        woodUITransform = transform.GetComponent<RectTransform>();
        woodUITransform.anchoredPosition = Vector3.Slerp(woodUITransform.anchoredPosition, target.anchoredPosition, 2f * Time.deltaTime);
        if (Vector2.Distance(woodUITransform.anchoredPosition, target.anchoredPosition) < 50)
        {
            Destroy(this.gameObject);
        }
    }
}
