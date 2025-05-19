using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.SceneManagement; // Importante per il cambio scena

public class LoginManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private string hashedPassword;

    public void TryLogin()
    {
        string enteredPassword = passwordInput.text;
        string enteredHash = ComputeSHA256Hash(enteredPassword);

        if (enteredHash == hashedPassword)
        {
            Debug.Log("Login riuscito!");
            SceneManager.LoadScene("New Scene");
        }
        else
        {
            Debug.Log("Password errata.");
        }
    }

    private string ComputeSHA256Hash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();

            foreach (byte b in hashBytes)
                builder.Append(b.ToString("x2"));

            return builder.ToString();
        }
    }
}
