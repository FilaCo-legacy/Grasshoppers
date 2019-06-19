namespace Grasshoppers.Models
{
    public interface IPaginationViewModel
    {
        int PageIndex { get; }

        int TotalPages { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }
        
    }
}