using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cats
{
    public class CatsDAL
    {
        private static string GetConnectionString()
        {
            return "Data Source=KAKIFISH;Initial Catalog=CatsDB;Integrated Security=True";
        }

        public Cat GetCat(string breed)
        {
            breed = breed.Trim();
            Cat cat = null;

            var conn = new SqlConnection(GetConnectionString());
            var sql = "SELECT * FROM Cats WHERE Breed = '" + breed + "'";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var catReader = cmd.ExecuteReader();
                if (catReader.HasRows)
                {
                    cat = new Cat(Convert.ToString(catReader["Breed"]).Trim(),
                                         Convert.ToString(catReader["Country"]).Trim(),
                                         Convert.ToString(catReader["Origin"]),
                                         Convert.ToString(catReader["Body Type"]).Trim(),
                                         Convert.ToString(catReader["Coat"]).Trim(),
                                         Convert.ToString(catReader["Pattern"]).Trim(),
                                         Convert.ToString(catReader["Wikipedia Link"]).Trim(),
                                         Convert.ToString(catReader["Image"]).Trim(),
                                         Convert.ToString(catReader["Information"]).Trim());
                }
            }
            catch (SqlException ex)
            {
                var msg = "GetCat Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
            return cat;
        }

        public void AddCat(Cat cat)
        {
            var conn = new SqlConnection(GetConnectionString());
            var sql = "INSERT INTO Cats VALUES('" + cat.GetBreed().Trim() + "','" + cat.GetCountry().Trim() + "','" + cat.GetOrigin().Trim() + "','" + cat.GetBodyType().Trim() + "','" + cat.GetCoat().Trim() + "','" + cat.GetPattern().Trim() + "','" + cat.GetWikipwdiaLink().Trim() + "','" + cat.GetImage().Trim() + "','" + cat.GetInfo().Trim() + "')";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                var msg = "AddCat Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        public LinkedList<Cat> GetAllCats()
        {
            var catsList = new LinkedList<Cat>();

            var conn = new SqlConnection(GetConnectionString());
            const string sql = "SELECT * FROM Cats";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var catsReader = cmd.ExecuteReader();
                if (catsReader.HasRows)
                {
                    while (catsReader.Read())
                    {
                        var cat = new Cat(Convert.ToString(catsReader["Breed"]).Trim(),
                                             Convert.ToString(catsReader["Country"]).Trim(),
                                             Convert.ToString(catsReader["Origin"]),
                                             Convert.ToString(catsReader["Body Type"]).Trim(),
                                             Convert.ToString(catsReader["Coat"]).Trim(),
                                             Convert.ToString(catsReader["Pattern"]).Trim(),
                                             Convert.ToString(catsReader["Wikipedia Link"]).Trim(),
                                             Convert.ToString(catsReader["Image"]).Trim(),
                                             Convert.ToString(catsReader["Information"]).Trim());
                        
                        if (catsList.Count == 0)
                        {
                            catsList.AddFirst(cat);
                        }
                        else
                        {
                            catsList.AddAfter(catsList.Last, cat);                            
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                var msg = "GetAllCats Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
            return catsList;
        }

        public LinkedList<string> GetListOfSpecification(string specificationName)
        {
            var specificationList = new LinkedList<string>();

            var conn = new SqlConnection(GetConnectionString());
            var sql = "SELECT DISTINCT [" + specificationName + "] FROM Cats";

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

        public string GetBreedSpecification(string breed, string specificationName)
        {
            string specification = null;

            var conn = new SqlConnection(GetConnectionString());
            var sql = "SELECT [" + specificationName + "] FROM Cats WHERE [Breed]='" + breed + "'";

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
                var msg = "GetSpecification Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
            return specification;
        }


        public void AddSpecificationToBreed(string breed, string specificationName, string specificationValue)
        {
            var conn = new SqlConnection(GetConnectionString());
            var sql = "UPDATE Cats SET [" + specificationName + "]='" + specificationValue + "' WHERE Breed='" + breed + "'";
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
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
        }
    }
}