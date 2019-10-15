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

    }

   public void OnPointerDown(Image image)
    {
        // set the new image based on what they clicked on
        Image previewImage = image;
        if (previewImage != null)
        {
            fullImage.sprite = previewImage.sprite;
            fullImage.type = Image.Type.Simple;
            fullImage.preserveAspect = true;
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
