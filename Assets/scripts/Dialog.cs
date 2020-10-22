
using localization;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Dialog : MonoBehaviour
{
    
    private string[] keys;
    private Button dialog;
    private MaskableGraphic[] children;
    private Text text;
    private Image image;
    private int current_id = 0;
    private Button open;
    private bool isOpenButton;
    private Image openImage;

    void Start()
    {
        dialog = GetComponent<Button>();
        open = GetComponentsInChildren<Button>()[1];
        open.onClick.AddListener(ClickOpenButton);
        openImage = open.GetComponent<Image>();
        children = GetComponentsInChildren<MaskableGraphic>();
        text = GetComponentInChildren<Text>();
        image = GetComponentsInChildren<Image>()[1]; 
        dialog.onClick.AddListener(NextKey);
        SetEnabled(false);
    }

    private void NextKey()
    {
        if (current_id + 1 < keys.Length)
        {
            current_id += 1;
            UpdateText();
        }
        else
        {
            SetEnabled(false);
        }
    }

    private void ClickOpenButton()
    {
        SetEnabled(true);
    }
    private void SetEnabled(bool e)
    {
        dialog.enabled = e;
        foreach (var component in children)
            component.enabled = e;
        open.enabled = false;
        openImage.enabled = false;
    }

    private void UpdateText()
    {
        text.text = LocalizationManager.Localize(keys[current_id]);
    }
    
    public void OpenDialog(Sprite sprite, string [] strings, bool isOpen)
    {
        isOpenButton = isOpen;
        current_id = 0;
        image.sprite = sprite;
        keys = strings;
        if (isOpenButton)
        {
            open.enabled = true;
            openImage.enabled = true;
        }
        else
            SetEnabled(true);
        UpdateText();
    }

    public void CloseDialog()
    {
        SetEnabled(false);
    }

}