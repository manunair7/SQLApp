using SQLApp.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLApp.Services
{
    public class CourseService
    {

        private SqlConnection GetConnection(string _connection_string)
        {
            return new SqlConnection(_connection_string);

        }

        public IEnumerable<Course> GetCourses(string _connection_string)
        {
            List<Course> _lst = new List<Course>();
            string _statement = "SELECT CourseID, CourseName, rating from Course";
            SqlConnection _conn = GetConnection(_connection_string);
            _conn.Open();
            SqlCommand _sqlCommand = new SqlCommand(_statement, _conn);
            using (SqlDataReader _reader = _sqlCommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Course _course = new Course()
                    {
                        CourseId = _reader.GetInt32(0),
                        CourseName = _reader.GetString(1),
                        Rating = _reader.GetDecimal(2)
                    };
                    _lst.Add(_course);
                }
            }
            _conn.Close();
            return _lst;
        }

    }
}
