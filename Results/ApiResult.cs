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
