using System.Collections;

namespace Grasshoppers.Models
{
    public interface IPaginationViewModel : IList
    {
        int PageIndex { get; }

        int TotalPages { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }
    }
}