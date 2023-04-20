using InvoiceCreator.Data;
using InvoiceCreator.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace InvoiceCreatorFrontend.Controllers
{
    public partial class InvoiceController : Controller
    {

        public IActionResult ViewTransaction(string searchString, string currentFilter, int? page)
        {
            // Set navbar indicator location
            ViewBag.indicatorLeft = "2.5%";
            ViewBag.indicatorOpacity = "1";
            ViewBag.selectedPage = "1";

            List<StudentModel> students = DatabaseHandler.getStudents();

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString)).ToList();
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(students.ToPagedList(pageNumber, pageSize));
            //return View(pagination.GetPageByNumber(transactions, pagination._currentPage));
        }
    }
}
