using System.Data.SqlClient;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Interfaces;

namespace OuvICEx.API.Repository.Repository
{
    public class SQLServerRepository : IRepository
    {
        private SqlConnection CreateConnection()
        {
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=OuvICEx;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return conn;
        }

        private List<string> GetSelectionClauses(PostSelectionFilter filter)
        {
            List<string> selection_clauses = new List<string>();

            if (filter.Context != null)
                selection_clauses.Add($"context = '{filter.Context}'");
            if (filter.AuthorDepartament != null)
                selection_clauses.Add($"author_departament = '{filter.AuthorDepartament}'");
            if (filter.TargetDepartament != null)
                selection_clauses.Add($"target_departament = '{filter.TargetDepartament}'");
            if (filter.IsResolved != null)
                selection_clauses.Add($"is_resolved = {filter.IsResolved}");

            return selection_clauses;
        }

        private string BuildSelectionSQLQuery(PostSelectionFilter filter)
        {
            string selection_query = "";
            List<string> selection_clauses = GetSelectionClauses(filter);

            if (selection_clauses.Count > 0)
            {
                selection_query = $"WHERE {selection_clauses[0]}";
                for (int i = 1; i < selection_clauses.Count; i++)
                    selection_query += $" and {selection_clauses[i]}";
            }

            return selection_query;
        }

        public List<PostInfo> GetPostsBasedOnSelectionFilter(PostSelectionFilter filter)
        {
            List<PostInfo> posts = new List<PostInfo>();
            SqlConnection connection = CreateConnection();

            string query = "SELECT * FROM Posts " + BuildSelectionSQLQuery(filter);
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        posts.Add(new PostInfo
                        {
                            Content = reader["content"].ToString(),
                            Context = reader["context"].ToString(),
                            AuthorDepartament = reader["author_departament"].ToString(),
                            TargetDepartament = reader["target_departament"].ToString(),
                            IsVisible = Convert.ToBoolean(reader["is_visible"].ToString()),
                            IsResolved = Convert.ToBoolean(reader["is_resolved"].ToString()),
                            CreatedDate = reader["created_date"].ToString()
                        });
                    }
                }
            }

            connection.Close();
            return posts;
        }
    }
}
