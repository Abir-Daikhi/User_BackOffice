using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class User
    {
        
            [Key]

            public int Id_User { get; set; }

            public string Name_User { get; set; }

            public string Family_Name_User { get; set; }

            public string Mail_User { get; set; }

            public string Login_User { get; set; }

            public string Mobile_Number_User { get; set; }

            public string Phone_Number_User { get; set; }

            public string Password_User { get; set; }

            public short Statut_User { get; set; }


        
    }
}
