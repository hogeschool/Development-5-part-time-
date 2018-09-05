using System;
using System.Collections.Generic;
using System.Linq;

namespace MapReduceCore
{
  public static class MapReduce
  {
    public static IEnumerable<T2> Map<T1, T2>(this IEnumerable<T1> table, Func<T1, T2> mapper)
    {
      T2[] result = new T2[table.Count()];
      for (int i = 0; i < table.Count(); i++)
      {
        result[i] = mapper(table.ElementAt(i));
      }
      return result;
    }

    public static State Reduce<State, T>(this IEnumerable<T> table, State init, Func<State, T, State> update)
    {
      State result = init;
      for (int i = 0; i < table.Count(); i++)
      {
        result = update(result, table.ElementAt(i));
      }
      return result;
    }

    public static IEnumerable<Tuple<T1,T2>> Join<T1, T2>
      (this IEnumerable<T1> leftTable, IEnumerable<T2> rightTable, Func<Tuple<T1, T2>, bool> condition)
    {
      return
        leftTable.Reduce<List<Tuple<T1, T2>>, T1>(new List<Tuple<T1, T2>>(),
          (queryResult, x) =>
          {
            List<Tuple<T1, T2>> combination =
              rightTable.Reduce(new List<Tuple<T1, T2>>(),
                      (c, y) =>
                      {
                        Tuple<T1, T2> row = new Tuple<T1, T2>(x, y);
                        if (condition(row))
                          c.Add(row);
                        return c;
                      });
            queryResult.AddRange(combination);
            return queryResult;
          });
    }
  }
}