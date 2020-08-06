using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementMVCWebApp.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please Enter A Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Contact Number")]
        public string ContactNumber { get; set; }
        [Range(1,Int32.MaxValue,ErrorMessage = "Select a Designation")]
        public int DesignationID { get; set; }
        [Range(1,Int32.MaxValue,ErrorMessage = "Select a Department")]
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Please Enter How Much Credit You Want To Take")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Negative Credit Is Not Allowed")]
        public double TotalCredit { get; set; }
        public double RemainingCredit { get; set; }



        //public int Id { get; set; }

        //[Required(ErrorMessage = "Please Enter Your Name")]
        //public string Name { get; set; }

        //[Required(ErrorMessage = "Please Enter Your Address")]
        //public string Address { get; set; }
        //[Required(ErrorMessage = "Please Enter Your Email")]
        //[RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please Enter A Valid Email")]
        //public string Email { get; set; }
        //[Required(ErrorMessage = "Please Enter Your Contact Number")]
        ////[StringLength(9, MinimumLength = 9, ErrorMessage = "Contact Number Must be 9 Characters Long")]
        //public string ContactNo { get; set; }

        //public int DesignationId { get; set; }
        //public int DepartmentId { get; set; }

        //[Required(ErrorMessage = "Please Enter How Much Credit You Want To Take")]
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Negative Credit Is Not Allowed")]
        //public double TotalCredit { get; set; }
        //public double RemainingCredit { get; set; }
    }
}