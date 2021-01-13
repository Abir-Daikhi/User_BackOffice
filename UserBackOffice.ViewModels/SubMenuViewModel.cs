using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBackOffice.ViewModels
{
    public class SubMenuViewModel
    {
        public int SubMenuId { get; set; }
        public string ControllerName { get; set; }
        public string ActionMethod { get; set; }
        public string SubMenuName { get; set; }
        public string MenuName { get; set; }
        public bool Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? MenuId { get; set; }
    }
}
