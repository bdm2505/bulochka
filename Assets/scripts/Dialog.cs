
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
    public Button open;
    private bool isOpenButton;
    private Image openImage;
    private Animator animator;

    void Start()
    {
        dialog = GetComponent<Button>();
        
        open.onClick.AddListener(Enabled);
        
        children = GetComponentsInChildren<MaskableGraphic>();
        text = GetComponentInChildren<Text>();
        image = GetComponentsInChildren<Image>()[1]; 
        dialog.onClick.AddListener(NextKey);
        animator = GetComponent<Animator>();
        if (open)
        {
            openImage = open.GetComponent<Image>();
            open.enabled = false;
            openImage.enabled = false;
        }
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
            CloseDialog();
        }
    }

    
    private void Enabled()
    {
        animator.Play("MoveUp");
        if (open)
        {
            open.enabled = false;
            openImage.enabled = false;
        }

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
        if (open && isOpenButton)
        {
            open.enabled = true;
            openImage.enabled = true;
        }
        else
            Enabled();
        UpdateText();
    }

    public void CloseDialog()
    {
        animator.Play("MoveDown");
        open.enabled = false;
        openImage.enabled = false;
    }

}