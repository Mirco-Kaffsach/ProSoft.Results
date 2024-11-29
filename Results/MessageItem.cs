namespace ProSoft.Results;

/// <summary>
/// Class MessageItem.
/// </summary>
/// <param name="Type">The type.</param>
/// <param name="RelevantField">The relevant field.</param>
/// <param name="Message">The message.</param>
public record MessageItem(MessageType Type,string RelevantField, string Message);