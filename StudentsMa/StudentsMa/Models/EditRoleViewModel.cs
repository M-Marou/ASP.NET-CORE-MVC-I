using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMa.Models
{
    public class EditRoleViewModel
    {

        public string Id { get; set; }

        [Required(ErrorMessage = "Please fill the role field")]
        [Display(Name ="Enter The New Name :")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }

    }
}
