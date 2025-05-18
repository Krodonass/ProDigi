using UnityEngine;

[CreateAssetMenu(fileName = "NewEmail", menuName = "ScriptableObjects/EmailData", order = 0)]
public class EmailData : ScriptableObject
{
    [Header("Email-Daten")]
    public string subject;   // Betreff der E-Mail
    public string sender;    // Absender der E-Mail
    
    [TextArea(3, 10)]
    public string content;   // Inhalt der E-Mail

    public float maxMailSize; // Maximum size of the mail content textbox
}
