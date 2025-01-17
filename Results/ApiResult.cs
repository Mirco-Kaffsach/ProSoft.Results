using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace ProSoft.Results;

/// <summary>
/// Class ApiResult. This class cannot be inherited.
/// Implements the <see cref="ProSoft.Results.Result{TValue}" />
/// </summary>
/// <typeparam name="TValue">The type of the t value.</typeparam>
/// <seealso cref="ProSoft.Results.Result{TValue}" />
public sealed class ApiResult<TValue> : Result<TValue>
{
    /// <summary>
    /// Gets or sets the status code.
    /// </summary>
    /// <value>The status code.</value>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// Gets a value indicating whether this instance is success status code.
    /// </summary>
    /// <value><c>true</c> if this instance is success status code; otherwise, <c>false</c>.</value>
    public bool IsSuccessStatusCode => ((int)StatusCode >= 200) && ((int)StatusCode <= 299);

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiResult{TValue}"/> class.
    /// </summary>
    public ApiResult()
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiResult{TValue}"/> class.
    /// </summary>
    /// <param name="statusCode">The status code.</param>
    /// <param name="value">The value.</param>
    /// <param name="resultType">Type of the result.</param>
    public ApiResult(HttpStatusCode statusCode, TValue? value, ResultType resultType)
        : base(value, resultType)
    {
        StatusCode = statusCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiResult{TValue}"/> class.
    /// </summary>
    /// <param name="statusCode">The status code.</param>
    /// <param name="value">The value.</param>
    /// <param name="resultType">Type of the result.</param>
    /// <param name="messages">The messages.</param>
    public ApiResult(HttpStatusCode statusCode, TValue? value, ResultType resultType, HashSet<MessageItem> messages) 
        : base(value, resultType, messages)
    {
        StatusCode = statusCode;
    }

    /// <summary>
    /// Ensures the success status code.
    /// </summary>
    /// <returns>ApiResult&lt;TValue&gt;.</returns>
    /// <exception cref="System.Net.Http.HttpRequestException">StatusCode indicates no success. - null</exception>
    public ApiResult<TValue> EnsureSuccessStatusCode()
    {
        if (!IsSuccessStatusCode)
        {
            throw new HttpRequestException
            (
                "StatusCode indicates no success.",
                null,
                StatusCode
            );
        }

        return this;
    }

    #region IDisposable Interface Implementation

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources.
    /// </summary>
    /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    [ExcludeFromCodeCoverage]
    protected override void Dispose(bool disposing)
    {
        // Local disposing logic goes here

        base.Dispose(disposing);
    }

    /// <summary>
    /// Finalizes an instance of the <see cref="Result{TValue}" /> class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    ~ApiResult()
    {
        this.Dispose(false);
    }

    #endregion
}
