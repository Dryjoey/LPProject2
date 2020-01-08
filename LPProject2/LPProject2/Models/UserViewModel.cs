using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Interfaces;

namespace LPProject2.Models
{
    public class UserViewModel 
    {
         
            public int Id { get; set; }
            [Display(Name = "Name")]
            public string Name { get; set; }
            [Display(Name = "Tel")]
            public int Phone { get; set; }
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Display(Name = "Nationalty")]
            public string Nationalty { get; set; }

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
                            Name = reader["Name"].ToString();


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
