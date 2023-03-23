using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] TMP_InputField textBox;
    [SerializeField] TMP_InputField printBox;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError(gameObject.name);

        printBox.text = "";
        textBox.text = "";
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public void DeleteLetter()
    {
        if(textBox.text.Length != 0) {
            textBox.text = textBox.text.Remove(textBox.text.Length - 1, 1);
        }
    }

    public void AddLetter(string letter)
    {
        if (textBox.text.Length < textBox.characterLimit)
            textBox.text = textBox.text + letter;
    }

    public void SubmitWord()
    {
        printBox.text = textBox.text;
    }
}
