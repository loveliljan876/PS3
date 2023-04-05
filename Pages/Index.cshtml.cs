using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PS3.Pages.Forms;

namespace PS3.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public YearForm Form { get; set; }

        public YearResponse? YearResponse { get; set; }

        public IndexModel()
        {
            Form = new YearForm();
            YearResponse = null;
        }

        public IActionResult OnGet()
        {


            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                YearResponse = new YearResponse(Form.Name, Form.Year.Value);
                SaveInSession(YearResponse);
            }

            return Page();
        }

        public List<YearResponse> GetResponses()
        {
            List<YearResponse>? currentList = new List<YearResponse>();
            var data = HttpContext.Session.GetString("Data");

            if (data != null)
            {
                currentList = JsonConvert.DeserializeObject<List<YearResponse>>(data);
                if (currentList == null)
                {
                    currentList = new List<YearResponse>();
                }
            }

            return currentList;
        }

        public void SaveInSession(YearResponse response)
        {
            var currentList = GetResponses();

            currentList.Add(response);
            HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(currentList));
        }
    }
}