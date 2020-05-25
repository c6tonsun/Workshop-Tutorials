using UnityEngine;
// this is needed for the TextMeshPro UI stuff
using TMPro;

// This will make this entire script run constantly so we can instantly see what changes to formats look like, use sparingly
// https://docs.unity3d.com/ScriptReference/ExecuteInEditMode.html
[ExecuteInEditMode]
public class CoolHUD : MonoBehaviour
{
    [SerializeField]
    // TextMeshProUGUI is TextMeshPro - Text (UI) in the editor
    private TextMeshProUGUI clickText = null;
    [SerializeField]
    // This is used to always have same text in the text field with just a different number
    // You could also add strings together but this lets you put something in the middle of a string easier
    // or even have multiple things combined into one string so you only need one text component in the UI
    // More info: https://docs.microsoft.com/en-us/dotnet/api/system.string.format
    private string clickFormat = "Clicks: {0}";
    [SerializeField]
    private string clickButton = "Fire1";
    private int clicks = 0;
    [SerializeField]
    private TextMeshProUGUI axisText = null;
    [SerializeField]
    // TextMeshPro can do advanced formatting like a line breaks with <br>
    // \n would also work in the actual text field but Unity automatically escapes it into \\n in strings so it doesn't work directly in this case
    private string axisFormat = "Horizontal Axis: {0}<br>Vertical Axis: {1}";
    [SerializeField]
    private string horAxis = "Horizontal";
    [SerializeField]
    private string verAxis = "Vertical";

    private void Start()
    {
        // reset clicks
        clicks = 0;
    }

    private void LateUpdate() // Running in LateUpdate so UI always updates after all other scripts
    {
        // Counting how many times Fire1 has been pressed
        if (Input.GetButtonDown(buttonName: clickButton))
            clicks++; // Braces are not absolutely required for single lines

        if (clickText) // equivalent to (clickText != null), we have to null check this or we get bombarded by errors in the editor
            // Using the format defined we can combine the string with number
            clickText.text = string.Format(format: clickFormat, arg0: clicks);

        if (axisText)
        {
            // Using unformatted floating point numbers looks awful in text
            axisText.text = string.Format(format: axisFormat, arg0: Input.GetAxis(horAxis).ToString(), Input.GetAxis(verAxis).ToString());

            // Number can be formatted when they are converted to strings so you always get exact number of decimals you want:
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings

            // Remove comment from the next line to see what it looks like (and comment out the other one)
            //axisText.text = string.Format(format: axisFormat, arg0: Input.GetAxis(horAxis).ToString(format: "f2"), Input.GetAxis(verAxis).ToString(format: "f2"));
        }
    }
}
