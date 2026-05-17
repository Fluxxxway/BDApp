using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace BDApp.Pages
{
    public class TestDBModel : PageModel
    {
        public List<string> Tables { get; set; } = new();

        public void OnGet()
        {
            var conn = new SqliteConnection("Data Source=app.db");
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table'";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tables.Add(reader.GetString(0));
            }
            conn.Close();
        }
    }
}
