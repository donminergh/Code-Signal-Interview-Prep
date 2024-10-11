using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class GroupingDishes
    {

        string[][] groupingDishes(string[][] dishes)
        {

            Dictionary<string, HashSet<string>> dict = new Dictionary<string, HashSet<string>>();

            foreach (var dish in dishes)
            {
                var dishName = dish.First();
                foreach (var ingredient in dish.Skip(1))
                {
                    if (!dict.ContainsKey(ingredient))
                    {
                        dict[ingredient] = new HashSet<string>();
                    }
                    dict[ingredient].Add(dishName);
                }
            }

            var ingredients = dict.Where(kvp => kvp.Value.Count > 1).OrderBy(kvp => kvp.Key, StringComparer.Ordinal).Select(
                kvp => {
                    var l = new List<string>() { kvp.Key };
                    l.AddRange(kvp.Value.OrderBy(x => x, StringComparer.Ordinal));
                    return l.ToArray();
                }).ToArray();

            return ingredients;
        }
    }
}
