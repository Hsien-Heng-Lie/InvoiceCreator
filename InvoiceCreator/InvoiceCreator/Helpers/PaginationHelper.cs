using InvoiceCreator.Models;

namespace InvoiceCreator.Helpers
{
    public class PaginationHelper
    {
        private int _pageSize;
        private int _totalPages;
        public int _currentPage { get; set; }

        public PaginationHelper(int pageSize, int currentPage, int totalRecords)
        {
            _pageSize = pageSize;
            _currentPage = currentPage;
            _totalPages = (totalRecords + (pageSize -1) )/pageSize;
        }

        public List<TransactionsModel> GetPageByNumber(List<TransactionsModel> transactions, int page) 
        {
            int indexFirstRecord;

            int Count = _pageSize;
            if(page < 0 || page > _totalPages)
            {
                page = _currentPage;
            }
            
            indexFirstRecord = (_pageSize * page) - _pageSize;
            if (indexFirstRecord < 0)
            {
                indexFirstRecord = 0;
            }
            if (indexFirstRecord + Count > transactions.Count)
            {
                Count = (transactions.Count - indexFirstRecord);
            }
            transactions = transactions.GetRange(indexFirstRecord, Count);
            _currentPage = page;
            
            return transactions;

        }

    }
}
