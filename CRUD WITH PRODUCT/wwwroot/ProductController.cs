using Microsoft.AspNetCore.Mvc;

namespace CRUD_WITH_PRODUCT.wwwroot
{
    public class ProductController : Controller
    {
        public class CategoryController : Controller
        {
            private readonly string connectionString = "YOUR_CONNECTION_STRING_HERE";

            // GET: Category
            public ActionResult Index()
            {
                List<Category> categories = new List<Category>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT CategoryId, CategoryName FROM Categories";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Category category = new Category
                            {
                                CategoryId = (int)reader["CategoryId"],
                                CategoryName = reader["CategoryName"].ToString()
                            };
                            categories.Add(category);
                        }
                    }
                }
                return View(categories);
            }

            // GET: Category/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Category/Create
            [HttpPost]
            public ActionResult Create(Category category)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                            command.ExecuteNonQuery();
                        }
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            // GET: Category/Edit/5
            public ActionResult Edit(int id)
            {
                Category category = new Category();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT CategoryId, CategoryName FROM Categories WHERE CategoryId = @CategoryId";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryId", id);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            category.CategoryId = (int)reader["CategoryId"];
                            category.CategoryName = reader["CategoryName"].ToString();
                        }
                    }
                }
                return View(category);
            }

            // POST: Category/Edit/5
            [HttpPost]
            public ActionResult Edit(int id, Category category)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                            command.Parameters.AddWithValue("@CategoryId", id);
                            command.ExecuteNonQuery();
                        }
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            // GET: Category/Delete/5
            public ActionResult Delete(int id)
            {
                Category category = new Category();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT CategoryId, CategoryName FROM Categories WHERE CategoryId = @CategoryId";
                }
            }

        }
    }

}
