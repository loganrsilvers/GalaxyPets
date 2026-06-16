using System.Security.Cryptography;
using System.Text;

namespace GalaxyPets.Services;

public class AuthService
{
    private readonly Dictionary<string, UserRecord> _users = new(StringComparer.OrdinalIgnoreCase);

    public string? CurrentUsername { get; private set; }
    public bool IsAuthenticated => CurrentUsername != null;

    public bool Register(string email, string username, string password, out string? error)
    {
        error = null;

        if (string.IsNullOrWhiteSpace(email))
        {
            error = "Email is required.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(username))
        {
            error = "Username is required.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
        {
            error = "Password must be at least 6 characters.";
            return false;
        }

        lock (_users)
        {
            if (_users.ContainsKey(username))
            {
                error = "This username is already taken.";
                return false;
            }

            if (_users.Values.Any(u => string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase)))
            {
                error = "This email is already registered.";
                return false;
            }

            _users[username] = new UserRecord(email, HashPassword(password));
            return true;
        }
    }

    public bool Login(string username, string password, out string? error)
    {
        error = null;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            error = "Username and password are required.";
            return false;
        }

        lock (_users)
        {
            if (!_users.TryGetValue(username, out var record))
            {
                error = "No account found with that username.";
                return false;
            }

            if (!string.Equals(record.PasswordHash, HashPassword(password), StringComparison.Ordinal))
            {
                error = "The password you entered was not valid.";
                return false;
            }

            CurrentUsername = username;
            return true;
        }
    }

    public void Logout()
    {
        CurrentUsername = null;
    }

    private static string HashPassword(string password)
        => Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));

    private sealed record UserRecord(string Email, string PasswordHash);
}
