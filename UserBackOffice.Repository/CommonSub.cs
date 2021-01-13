using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using UserBackOffice.Models;

namespace UserBackOffice.Repository
{
    public class CommonSub
    {
        public static List<SubMenu> ShowSubMenu(int menuId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@MenuId", menuId);
                    return con.Query<SubMenu>("Usp_GetAllSubMenuByMenuId", param, null, false, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
