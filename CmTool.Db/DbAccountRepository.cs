using System;
using System.Collections.Generic;
using System.Data.SqlClient;



namespace CmTool.Db
{

    public class DbAccountRepository
    {
        private string conString;
        public DbAccountRepository(string conString)
        {
            this.conString = conString;
        }

        public List<Account> GetAllUsers()
        {
            var res = new List<Account>();
            using (var con = new SqlConnection(conString))
            {
                var cmd = new SqlCommand("SELECT * FROM Users", con);
                con.Open();
                var result = cmd.ExecuteReader();                

                while (result.Read())
                {                   
                    res.Add(new Account
                    {
                        //Id = int.Parse(result["ID"].ToString()),
                        DisplayName = result["Display_Name"].ToString().Trim(),
                        is_Admin = Convert.ToBoolean(result["is_Admin"]),
                        FirstName = result["FirstName"].ToString().Trim(),
                        LastName = result["LastName"].ToString().Trim(),
                        Mail = result["Mail"].ToString().Trim(),
                        Password = result["Password"].ToString().Trim(),
                        UserName = result["UserName"].ToString().Trim()
                    });
                }
                con.Close();
            }
            return res;
        }
    }

    public class Account
    {

        public int Id { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mail { get; set; }

        public bool is_Admin { get; set; }

        public string DisplayName { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
