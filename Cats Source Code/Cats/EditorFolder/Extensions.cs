using System.Collections.Generic;
using System.Web.UI;

namespace Cats.EditorFolder
{
    public static class Extensions
    {
        public static IEnumerable<Control> FindAll(this ControlCollection collection)
        {
            foreach (Control item in collection)
            {
                yield return item;

                if (!item.HasControls()) continue;
                foreach (var subItem in item.Controls.FindAll())
                {
                    yield return subItem;
                }
            }
        }
    }
}