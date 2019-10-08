using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(GraphicRaycaster))]

public class ImageSelector : MonoBehaviour
{
    public string categoryTitleName;
    public Text categoryTitle;
    public Image fullImage;
    public Material highlightMaterial;
    // Start is called before the first frame update
    void Start()
    {
        categoryTitle.text = categoryTitleName;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnPointerDown();
        }
    }

   public void OnPointerDown()
    {
        GraphicRaycaster gr = GetComponent<GraphicRaycaster>();
        PointerEventData data = new PointerEventData(null);
        data.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(data, results);

        if(results.Count > 0)
        {
            // This means we got a hit
            OnPreviewClick(results[0].gameObject);
        }
    }
    public void OnPreviewClick(GameObject thisButton)
    {
        // set the new image based on what they clicked on
        Image previewImage = thisButton.GetComponent<Image>();
        if(previewImage != null)
        {
            fullImage.sprite = previewImage.sprite;
            fullImage.type = Image.Type.Simple;
            fullImage.preserveAspect = true;
        }
    }
    public void OnPointerEnter(Image image)
    {
        // when the user's gaze points to an image, highlight gameObject
        image.material = highlightMaterial;
        Debug.Log("Called OnPointerEnter");
    }
    public void OnPointerExit(Image image)
    {
        image.material = null;

    }
}
