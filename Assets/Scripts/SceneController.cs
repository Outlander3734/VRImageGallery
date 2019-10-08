using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject galleryHolder;
    public float slideSpeed;

    private OVRTouchpad.TouchEvent touchEvent;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        OVRTouchpad.Create();
        OVRTouchpad.AddListener(SwipeHandler);
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(SwipeRight(galleryHolder.transform.position.x));
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(SwipeLeft(galleryHolder.transform.position.x));
            }
        }
        #endif
    }
    void SwipeHandler(OVRTouchpad.TouchEvent button)
    {
        if (!isMoving)
        {
            if (button == OVRTouchpad.TouchEvent.Left)
            {
                StartCoroutine(SwipeLeft(galleryHolder.transform.position.x));
            }
            else if (button == OVRTouchpad.TouchEvent.Right)
            {
                StartCoroutine(SwipeRight(galleryHolder.transform.position.x));
            }
        }
    }
    private IEnumerator SwipeRight(float startingXPos)
    {
        while (galleryHolder.transform.position.x != startingXPos - 4)
        {
            isMoving = true;
            Vector3 V3R = new Vector3(startingXPos - 4, galleryHolder.transform.position.y, 0f);
            galleryHolder.transform.position = Vector3.MoveTowards(galleryHolder.transform.position, V3R, slideSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }
    private IEnumerator SwipeLeft(float startingXPos)
    {
        while (galleryHolder.transform.position.x != startingXPos + 4)
        {
            isMoving = true;
            Vector3 V3L = new Vector3(startingXPos + 4, galleryHolder.transform.position.y, 0f);
            galleryHolder.transform.position = Vector3.MoveTowards(galleryHolder.transform.position, V3L, slideSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }
}
