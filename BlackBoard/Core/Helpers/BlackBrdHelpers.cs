using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BlackBoard.Core.Models;

namespace BlackBoard.Core.Helpers
{
    public static class BlackBrdHelpers
    {
        public static IEnumerable<SelectListItem> DivisionToSelectList()
        {
            var divisionItems = EnumHelpers.ToSelectList(typeof(Division)).ToList();
            divisionItems.Insert(0, new SelectListItem { Text = "Select", Value = "" });
            return divisionItems;
        }
        public static IEnumerable<SelectListItem> LevelToSelectList()
        {
            var divisionItems = EnumHelpers.ToSelectList(typeof(Level)).ToList();
            divisionItems.Insert(0, new SelectListItem { Text = "Select", Value = "" });
            return divisionItems;
        }
        public static IEnumerable<SelectListItem> NameToSelectList()
        {
            var divisionItems = EnumHelpers.ToSelectList(typeof(Naming)).ToList();
            divisionItems.Insert(0, new SelectListItem { Text = "Select", Value = "" });
            return divisionItems;
        }

    }
}