using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace ProSoft.Results;

/// <summary>
/// Class ApiPagedResult. This class cannot be inherited.
/// Implements the <see cref="ProSoft.Results.PagedResult{TValue}" />
/// </summary>
/// <typeparam name="TValue">The type of the t value.</typeparam>
/// <seealso cref="ProSoft.Results.PagedResult{TValue}" />
public sealed class ApiPagedResult<TValue> : PagedResult<TValue>
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
    /// Ensures the success status code.
    /// </summary>
    /// <returns>ApiPagedResult&lt;TValue&gt;.</returns>
    /// <exception cref="System.Net.Http.HttpRequestException">StatusCode indicates no success. - null</exception>
    public ApiPagedResult<TValue> EnsureSuccessStatusCode()
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

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiPagedResult{TValue}"/> class.
    /// </summary>
    public ApiPagedResult()
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiPagedResult{TValue}"/> class.
    /// </summary>
    /// <param name="resultList">The result list.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="currentPage">The current page.</param>
    public ApiPagedResult(HttpStatusCode statusCode, IQueryable<TValue> resultList, int pageSize, int currentPage) 
        : base(resultList, pageSize, currentPage)
    {
        StatusCode = statusCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiPagedResult{TValue}"/> class.
    /// </summary>
    /// <param name="statusCode">The status code.</param>
    /// <param name="resultList">The result list.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="currentPage">The current page.</param>
    /// <param name="resultType">Type of the result.</param>
    public ApiPagedResult(HttpStatusCode statusCode, IQueryable<TValue> resultList, int pageSize, int currentPage, ResultType resultType)
        : base(resultList, pageSize, currentPage, resultType)
    {
        StatusCode = statusCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiPagedResult{TValue}"/> class.
    /// </summary>
    /// <param name="statusCode">The status code.</param>
    /// <param name="resultList">The result list.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="currentPage">The current page.</param>
    /// <param name="resultType">Type of the result.</param>
    /// <param name="messages">The messages.</param>
    public ApiPagedResult(HttpStatusCode statusCode, IQueryable<TValue> resultList, int pageSize, int currentPage, ResultType resultType, HashSet<MessageItem> messages)
        : base(resultList, pageSize, currentPage, resultType, messages)
    {
        StatusCode = statusCode;
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
    /// Finalizes an instance of the <see cref="PagedResult{TValue}" /> class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    ~ApiPagedResult()
    {
        this.Dispose(false);
    }

    #endregion
}
