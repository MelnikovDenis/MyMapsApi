namespace MyMapsApi.Shared;

/// <summary>
/// Класс-хелпер для хеширования
/// </summary>
public static class HashHelper
{
    /// <summary>
    /// Создать хэш bcrypt
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <returns>Строка с bcrypt хэшем</returns>
    public static string CreateHash(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password, BCrypt.Net.HashType.SHA256);
    }
    
    /// <summary>
    /// Верифицировать пароль
    /// </summary>
    /// <param name="currentHash">Хэш</param>
    /// <param name="password">Пароль</param>
    /// <returns>Является ли пароль валидным</returns>
    public static bool VerifyHash(string currentHash, string password)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, currentHash, BCrypt.Net.HashType.SHA256);
    }
}
