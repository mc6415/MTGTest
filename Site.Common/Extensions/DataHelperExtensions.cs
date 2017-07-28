using System.Data;
using System.Linq;

namespace Site.Common.Extensions
{
    public static class DataHelperExtensions
    {
        /// <summary>
        /// Checks if dataset contains rows of data.
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static bool IsEmpty(this DataSet dataSet)
        {
            return dataSet.Tables.Cast<DataTable>().All(table => table.Rows.Count == 0);
        }
    }
}
