namespace ProSoft.Results;

/// <summary>
/// Class Result.
/// </summary>
/// <typeparam name="TValue">The type of the t value.</typeparam>
public class Result<TValue>
{
   /// <summary>
   /// Gets or sets the value.
   /// </summary>
   /// <value>The value.</value>
   public TValue? Value { get; set; }

   /// <summary>
   /// Gets or sets the type.
   /// </summary>
   /// <value>The type.</value>
   public ResultType Type { get; set; }

   /// <summary>
   /// Gets or sets the messages.
   /// </summary>
   /// <value>The messages.</value>
   public HashSet<MessageItem> Messages { get; set; } = [];
}