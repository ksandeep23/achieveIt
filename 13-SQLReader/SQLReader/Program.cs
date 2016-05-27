using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Npgsql;
using NpgsqlTypes;
using System.Web.UI.HtmlControls;

namespace SQLReader
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSQLQueryAndDisplayHTMLTable();
            Console.Read();
        }

        /// <summary>
        /// A simple class to hold a (employee, manager) tuple
        /// </summary>
        class EmployeeManagerTuple
        {
            /// <summary>
            /// Employee name
            /// </summary>
            public string employee { get; set; }

            /// <summary>
            /// Manager name
            /// </summary>
            public string manager { get; set; }
        }

        /// <summary>
        /// Run the SQL query to retrieve the (employee, manager) tuple and display as a html table.
        /// I am using a personal Postgres SQL server. Also I am using the Npgsql library to connect to the Postgres db.
        /// Documentation for this library can be found at: http://www.npgsql.org/doc/index.html
        /// The db connection parameters are masked because they refer to a local postgres db that cannot be accessed publicly.
        /// </summary>
        static void RunSQLQueryAndDisplayHTMLTable() {
            using (var conn = new NpgsqlConnection("Host=XXXXX;Username=YYYYYY;Password=ZZZZZZ;Database=DDDDDDDDD"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // The SQL command to retrieve the (employee, manager) tuple
                    cmd.CommandText = "SELECT employee.name AS EMPLOYEE_NAME, manager.name AS MANAGER_NAME FROM employee AS employee LEFT JOIN employee AS manager ON employee.mgr_id = manager.id;";
                    
                    // Create a list of all retrieved (employee, manager) tuples
                    using (var reader = cmd.ExecuteReader())
                    {
                        var employeeManagerTupleList = new List<EmployeeManagerTuple>();
                        while (reader.Read())
                        {
                            var tuple = new EmployeeManagerTuple();
                            try
                            {
                                tuple.employee = reader.GetString(0);
                                tuple.manager = reader.GetString(1);
                            }
                            catch { }
                            employeeManagerTupleList.Add(tuple);
                        }

                        //Convert the list into html table and display.
                        DisplayHtmlTable(employeeManagerTupleList);
                    }
                }
            }
        }

        /// <summary>
        /// Convert the list of (employee,manager) tuples to an html table and display it.
        /// Used documentation for the HtmlTable from: https://msdn.microsoft.com/en-us/library/system.web.ui.htmlcontrols.htmltable(v=vs.110).aspx
        /// 
        /// </summary>
        /// <param name="employeeManagerTupleList"> The list of (employee, manager) tuples </param>
        static void DisplayHtmlTable(List<EmployeeManagerTuple> employeeManagerTupleList)
        {
            var table = new HtmlTable();
            foreach (var tuple in employeeManagerTupleList)
            {
                var row = new HtmlTableRow();
                var cell0 = new HtmlTableCell();
                cell0.InnerText = tuple.employee;
                var cell1 = new HtmlTableCell();
                cell1.InnerText = tuple.manager;
                row.Cells.Add(cell0);
                row.Cells.Add(cell1);
                table.Rows.Add(row);
            }

            StringWriter stringWriter = new StringWriter();
            table.RenderControl(new System.Web.UI.HtmlTextWriter(stringWriter));
            Console.WriteLine(stringWriter.ToString());

        }
    }
}
