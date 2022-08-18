using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace SchoolSundayRH.Models
{
    public partial class SelectedTipoEvaluaciones
    {
        public int ID { get; set; }
        public int[] TipoEvaluacionIDs { get; set; }

        public List<SelectListItem> ItemList { get; set; }
    }
}
