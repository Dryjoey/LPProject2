using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DAL;

namespace LPProject2.Models
{
    public class UserViewModel
    {
         
            public int UserId { get; set; }
            [Display(Name = "Name")]
            public string UserName { get; set; }
            [Display(Name = "Tel")]
            public string UserPhone { get; set; }
            [Display(Name = "Email")]
            public string UserEmail { get; set; }
            [Display(Name = "Nationalty")]
            public string UserNationalty { get; set; }

            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Please enter your Password.")]
            [Display(Name = "Password : ")]
            public string Password { get; set; }

            public String LoginProcess(String strUsername, String strPassword)
            {
                String message = "";
                //my connection string
                DAO dao = new UserDAO();

                SqlCommand cmd = new SqlCommand("Select* from User where Name=@Name", dao.con);
                cmd.Parameters.AddWithValue("@Name", strUsername);
                try
                {
                    dao.con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Boolean login = (strPassword.Equals(reader["Password"].ToString(), StringComparison.InvariantCulture)) ? true : false;
                        if (login)
                        {
                            message = "1";
                            UserName = reader["Name"].ToString();


                        }
                        else
                            message = "Invalid Credentials";
                    }
                    else
                        message = "Invalid Credentials";

                    reader.Close();
                    reader.Dispose();
                    cmd.Dispose();
                    dao.con.Close();
                }
                catch (Exception ex)
                {
                    message = ex.Message.ToString() + "Error.";

                }
                return message;
            }
        }
}
