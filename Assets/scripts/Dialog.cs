
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

    void Start()
    {
        dialog = GetComponent<Button>();
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
    private void SetEnabled(bool e)
    {
        dialog.enabled = e;
        foreach (var component in children)
            component.enabled = e;
    }

    private void UpdateText()
    {
        text.text = LocalizationManager.Localize(keys[current_id]);
    }
    
    public void OpenDialog(Sprite sprite, string [] strings)
    {
        current_id = 0;
        image.sprite = sprite;
        keys = strings;
        SetEnabled(true);
        UpdateText();
    }

    public void CloseDialog()
    {
        SetEnabled(false);
    }

}