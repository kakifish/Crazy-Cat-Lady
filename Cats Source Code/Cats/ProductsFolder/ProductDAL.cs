using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cats.ProductsFolder
{
    public class ProductDAL
    {
        private static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["CatsDB"].ConnectionString;
        }

        public Product GetProduct(string productName)
        {
            productName = productName.Trim();
            Product product = null;

            var conn = new SqlConnection(GetConnectionString());
            var sql = "SELECT * FROM Products WHERE [Product Name] = '" + productName + "'";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var productReader = cmd.ExecuteReader();
                if (productReader.HasRows)
                {
                    productReader.Read();
                    product = new Product(Convert.ToString(productReader["Category"]).Trim(),
                        Convert.ToString(productReader["Product Name"]).Trim(),
                        Convert.ToString(productReader["Description"]).Trim(),
                        Convert.ToString(productReader["Image"]),
                        Convert.ToString(productReader["Price"]).Trim(),
                        Convert.ToString(productReader["Brand"]).Trim(),
                        Convert.ToString(productReader["Weight"]).Trim(),
                        Convert.ToString(productReader["Store Name"]).Trim(),
                        Convert.ToString(productReader["Store Address"]).Trim(),
                        Convert.ToString(productReader["Store Phone"]).Trim());
                }
            }
            catch (SqlException ex)
            {
                var msg = "GetProduct Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
            return product;
        }

        public void AddProduct(Product product)
        {
            var conn = new SqlConnection(GetConnectionString());
            var sql = "INSERT INTO Products VALUES('" + product.GetCategory().Trim() + "','" + product.GetProductName().Trim() + "','" + product.GetImage().Trim() + "','" + product.GetDescription().Trim() + "','" + product.GetPrice().Trim() + "','" + product.GetBrand().Trim() + "','" + product.GetWeight().Trim() + "','" + product.GetStoreName().Trim() + "','" + product.GetStoreAddress().Trim() + "','" + product.GetStorePhone().Trim() + "')";
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                var msg = "AddProduct Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        public LinkedList<Product> GetCategoryList(string category)
        {
            var categoryList = new LinkedList<Product>();

            var conn = new SqlConnection(GetConnectionString());
            var sql = "SELECT * FROM Products WHERE Category = '" + category + "'";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var productReader = cmd.ExecuteReader();
                if (productReader.HasRows)
                {
                    while (productReader.Read())
                    {
                        var product = new Product(Convert.ToString(productReader["Category"]).Trim(),
                            Convert.ToString(productReader["Product Name"]).Trim(),
                            Convert.ToString(productReader["Description"]).Trim(),
                            Convert.ToString(productReader["Image"]),
                            Convert.ToString(productReader["Price"]).Trim(),
                            Convert.ToString(productReader["Brand"]).Trim(),
                            Convert.ToString(productReader["Weight"]).Trim(),
                            Convert.ToString(productReader["Store Name"]).Trim(),
                            Convert.ToString(productReader["Store Address"]).Trim(),
                            Convert.ToString(productReader["Store Phone"]).Trim());

                        if (categoryList.Count == 0)
                        {
                            categoryList.AddFirst(product);
                        }
                        else
                        {
                            categoryList.AddAfter(categoryList.Last, product);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                var msg = "GetCategoryList Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
            return categoryList;
        }

        //////////// OPTIONAL /////////////
        public LinkedList<string> GetListOfSpecification(string specificationName)
        {
            var specificationList = new LinkedList<string>();

            var conn = new SqlConnection(GetConnectionString());
            var sql = "SELECT DISTINCT [" + specificationName + "] FROM Products";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var specificationReader = cmd.ExecuteReader();
                if (specificationReader.HasRows)
                {
                    while (specificationReader.Read())
                    {
                        var rowInSpecificationColumn = Convert.ToString(specificationReader[specificationName]).Trim();
                        if (specificationList.Count == 0)
                        {
                            specificationList.AddFirst(rowInSpecificationColumn);
                        }
                        else
                        {
                            specificationList.AddAfter(specificationList.Last, rowInSpecificationColumn);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                var msg = "GetSpecification Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
            return specificationList;
        }
        //////// END OF OPTIONAL ///////////

        public string GetCategorySpecification(string category, string specificationName)
        {
            string specification = null;

            var conn = new SqlConnection(GetConnectionString());
            var sql = "SELECT [" + specificationName + "] FROM Products WHERE [Category]='" + category + "'";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var specificationReader = cmd.ExecuteReader();
                specificationReader.Read();
                if (specificationReader.HasRows)
                {
                    try
                    {
                        specification = Convert.ToString(specificationReader[specificationName]).Trim();
                    }
                    catch (Exception)
                    {
                        return specification;
                    }
                }
            }
            catch (SqlException ex)
            {
                var msg = "GetCategorySpecification Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
            return specification;
        }

        public void AddSpecificationToProduct(string productName, string specificationName, string specificationValue)
        {
            var conn = new SqlConnection(GetConnectionString());
            var sql = "UPDATE Products SET [" + specificationName + "]='" + specificationValue + "' WHERE [Product Name]='" + productName + "'";
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                var msg = "AddSpecificationToProduct Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        //public void DeleteProduct(????)
        //{
        //    var conn = new SqlConnection(GetConnectionString());
        //    var sql = "DELETE FROM Products WHERE ????"

        //    try
        //    {
        //        conn.Open();
        //        var cmd = new SqlCommand(sql, conn);

        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        var msg = "DeleteProduct Sql Error: ";
        //        msg += ex.Message;
        //        throw new Exception(msg);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
    }
}