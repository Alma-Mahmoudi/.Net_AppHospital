using LanguageExt;
using MaxMind.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AppHospital.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        public List<DoctorInfo> listDoctors = new List<DoctorInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\SQLExpress;Initial Catalog=Hospital;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); 
                    String sql = "SELECT * from doctors";
                    using (SqlCommand command = new SqlCommand(sql, connection))    
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DoctorInfo doctorInfo = new DoctorInfo();
                                doctorInfo.id = "" + reader.GetInt32(0);
                                doctorInfo.name = reader.GetString(1);
                                doctorInfo.email = reader.GetString(2);
                                doctorInfo.phone = reader.GetString(3);
                                doctorInfo.adress = reader.GetString(4);
                                doctorInfo.specialtie = reader.GetString(5);
                                doctorInfo.created_at = reader.GetDateTime(6).ToString();

                            }
                        }
                       
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
    }

    public class DoctorInfo
    {
        public String id;
        public String name;
        public String email;
        public String phone;
        public String adress;
        public String specialtie;
        public String created_at;

    }
}
