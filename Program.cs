using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlKata;
using SqlKata.Execution;
using System.Data.SqlClient;
using SqlKata.Compilers;

namespace SqlKata.Sample
{
	class Program
	{
		static void Main(string[] args)
		{
			var connection = new SqlConnection(@"Data Source=DATASOURCE;initial Catalog=DATABASE;User Id=USER;Password=PASSWORD");
			var compiler = new SqlServerCompiler();

			var db = new QueryFactory(connection, compiler);

			UserList(db);

			SearchUser(db);

			Console.ReadLine();
		}

		private static void SearchUser(QueryFactory db)
		{
			IEnumerable<dynamic> userSearch = db.Query("Users").Where("UserId", 2).WhereTrue("State").Get();

			Console.WriteLine("\r\nUser Search ------\r\n ");
			foreach (var user in userSearch)
			{
				Console.WriteLine($"Id: {user.UserId}, SurName: {user.FirstName}, First Name: {user.LastName}");
			}
		}

		private static void UserList(QueryFactory db)
		{
			IEnumerable<dynamic> users = db.Query("Users").Get();

			Console.WriteLine("User List ------\r\n");
			foreach (var user in users)
			{
				Console.WriteLine($"Id: {user.UserId}, SurName: {user.FirstName}, First Name: {user.LastName}");
			}
		}
	}
}
