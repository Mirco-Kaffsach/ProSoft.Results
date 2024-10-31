namespace ProSoft.Results;

/// <summary>
/// Class PagedResult.
/// </summary>
/// <typeparam name="TValue">The type of the t value.</typeparam>
public class PagedResult<TValue>
{
   /// <summary>
   /// Gets or sets the result list.
   /// </summary>
   /// <value>The result list.</value>
   public List<TValue> ResultList { get; set; }

   /// <summary>
   /// Gets the size of the page.
   /// </summary>
   /// <value>The size of the page.</value>
   public int PageSize { get; private set; }

   /// <summary>
   /// Gets the page count.
   /// </summary>
   /// <value>The page count.</value>
   public int PageCount { get; private set; }

   /// <summary>
   /// Gets the current page.
   /// </summary>
   /// <value>The current page.</value>
   public int CurrentPage { get; private set; }

   /// <summary>
   /// Gets the total count.
   /// </summary>
   /// <value>The total count.</value>
   public long TotalCount { get; private set; }

   /// <summary>
   /// Initializes a new instance of the <see cref="PagedResult{TValue}"/> class.
   /// </summary>
   /// <param name="resultList">The result list.</param>
   /// <param name="pageSize">Size of the page.</param>
   /// <param name="currentPage">The current page.</param>
   public PagedResult(IQueryable<TValue> resultList, int pageSize, int currentPage)
   {
      PageSize = pageSize;
      TotalCount = resultList.LongCount();

      double totalPages = (double)TotalCount / (double)pageSize;
      if (totalPages % 1 != 0)
      {
         totalPages = Math.Ceiling(totalPages);
      }

      PageCount = (int)totalPages;

      if (currentPage <= 0)
         currentPage = 1;

      if (currentPage > PageCount)
         currentPage = PageCount;

      CurrentPage = currentPage;
      ResultList = resultList.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
   }
}
