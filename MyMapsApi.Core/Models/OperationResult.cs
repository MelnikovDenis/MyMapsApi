namespace MyMapsApi.Core.Models;

/// <summary>
/// Результат операции
/// </summary>
/// <typeparam name="T">Параметр</typeparam>
public class OperationResult<T>
{
    /// <summary>
    /// Данные результата операции
    /// </summary>
    public T? Data { get; private set; }

    /// <summary>
    /// Успешен ли результат операции
    /// </summary>
    public bool IsSuccess { get => errors.Count == 0; }

    /// <summary>
    /// Http статус-код
    /// </summary>
    public int StatusCode { get; private set; }

    /// <summary>
    /// Внутренний список ошибок
    /// </summary>
    private readonly List<string> errors = [];

    /// <summary>
    /// Внешний неизменяемый список ошибок
    /// </summary>
    public IReadOnlyList<string> Errors { get => errors; }

    /// <summary>
    /// Конструктор для успешной операции
    /// </summary>
    /// <param name="data">Данные успешной операции</param>
    public OperationResult(T data)
    {
        Data = data;
        StatusCode = 200;
    }

    /// <summary>
    /// Конструктор неуспешного результата операции со множеством ошибок
    /// </summary>
    /// <param name="errorMessages">Множество ошибок</param>
    /// <param name="statusCode">Http статус код ответа</param>
    public OperationResult(IEnumerable<string> errorMessages, int statusCode)
    {
        errors.AddRange(errorMessages);
        Data = default;
        StatusCode = statusCode;
    }

    /// <summary>
    /// Конструктор неуспешного результата операции с одной ошибкой
    /// </summary>
    /// <param name="errorMessage">Сообщение об ошибке</param>
    /// <param name="statusCode">Http статус код ответа</param>
    public OperationResult(string errorMessage, int statusCode)
    {
        errors.Add(errorMessage);
        Data = default;
        StatusCode = statusCode;
    }

    /// <summary>
    /// Преобразовать в OperationResult с другим типом параметра
    /// </summary>
    /// <typeparam name="T1">Параметр выходного OperationResult</typeparam>
    /// <param name="conv">Функция-конвертер для поля Data у OperationResult</param>
    public OperationResult<T1> Convert<T1>(Func<T, T1> conv)
    {
        if (IsSuccess && Data != null)
            return new OperationResult<T1>(conv.Invoke(Data));

        return new OperationResult<T1>(Errors, StatusCode);
    }
}