using Riodetask.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riodetask.AppCode.NewFolder
{
    public static partial class CategoryExtension
    {
        public static string GetCategory(this List<Category> categories)
        {
            if (categories==null || !categories.Any())
            {
                return "";
            }

            StringBuilder str = new StringBuilder();
            foreach (var item in categories)
            {
                GetChildren(item);
            }
  
            return str.ToString();

             void GetChildren(Category category)
            {
                str.Append("<li>");
                str.Append($"<a href='#'> {category.Name} </a>");
                if (category.Children!=null && category.Children.Any())
                {
                    str.Append("<ul>");
                    foreach (var item in category.Children)
                    {
                        GetChildren(item);
                    }

                    str.Append("</ul>");
                }
                str.Append("</li>");
            }


        }
        public static IEnumerable<Category> GetChild(this Category category)
        {
            if (category.ParentID != null)
                yield return category;

            if (category.Children != null)
            {
                foreach (var item in category.Children.SelectMany(c=>c.GetChild()))
                {
                    yield return item;
                }
            }
        }
    }
}
