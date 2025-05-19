using UnityEngine;
using System.Security.Cryptography;
using System.Text;

public class EditorPasswordHasher : MonoBehaviour
{
    [SerializeField] private string plainTextPassword;

    [ContextMenu("Genera Hash SHA-256")]
    private void GenerateHash()
    {
        if (string.IsNullOrEmpty(plainTextPassword))
        {
            Debug.LogWarning("Inserisci una password da codificare.");
            return;
        }

        string hashedPassword = ComputeSHA256Hash(plainTextPassword);
        Debug.Log($"Hash SHA-256: {hashedPassword}");
    }

    private string ComputeSHA256Hash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();

            foreach (byte b in hashBytes)
                builder.Append(b.ToString("x2")); // Hexadecimal format

            return builder.ToString();
        }
    }
}
