using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Login
{
   public class ClsLogin
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public UserLogin Model { get; set; }

        public ClsLogin()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new UserLogin();
        }

        public string SaveLogin()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            //if (Model.Tag == "NEW")
            //{
                strSql.Append("declare @LogInId int=(select ISNULL((Select Top 1 max(cast(LogInId as int))  from UserLogin),0)+1) \n");
                strSql.Append("Insert into UserLogin(LogInId, LoginUserName, LoginPassword) \n");
                strSql.Append("Select @LogInId,'" + Model.LoginUserName.Trim() + "','" + Model.LoginPassword.Trim() + "'\n");
                strSql.Append("SET @VNo =@LogInId");

           // }
            //else if (Model.Tag == "EDIT")
            //{
            //    strSql.Append("UPDATE UserLogin SET [LoginUserName] = '" + Model.LoginUserName.Trim() + "',[BranchShortName] = '" + Model.LoginPassword.Trim() + "' where LoginId='"+Model.LoginId+"'");
            //    strSql.Append("SET @VNo ='" + Model.LoginId + "'");
            //}
            //else if (Model.Tag == "DELETE")
            //{
            //    strSql.Append("DELETE FROM UserLogin WHERE BranchId = '" + Model.LoginId + "' \n");
            //    strSql.Append("SET @VNo ='1'");
            //}

            strSql.Append("\n COMMIT TRANSACTION \n");
            strSql.Append("END TRY \n");
            strSql.Append("BEGIN CATCH \n");
            strSql.Append("ROLLBACK TRANSACTION \n");
            strSql.Append("Set @VNo = '' \n");
            strSql.Append("END CATCH \n");

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@VNo", SqlDbType.VarChar, 25);
            p[0].Direction = ParameterDirection.Output;
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString(), p);
            return p[0].Value.ToString();
        }
    }
           
    public class UserLogin
    {
        public string Tag { get; set; }
        public int LoginId { get; set; }
 
        public string LoginUserName { get; set; }
        public string LoginPassword { get; set; }
      
    }

}
