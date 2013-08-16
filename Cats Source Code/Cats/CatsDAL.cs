using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cats
{
    public class CatsDAL
    {
        private readonly string _table;
        private readonly bool _admin;

        public CatsDAL(bool admin)
        {
            _table = "Cats";
            if (admin)
            {
                _table += "Admin";
            }
            _admin = admin;
        }
        
        private static string GetConnectionString()//good
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["CatsDB"].ConnectionString;
        }

        public Cat GetCat(string breed)
        {
            Cat cat = null;

            var conn = new SqlConnection(GetConnectionString());
            var sql = "SELECT * FROM " + _table + " WHERE [Breed]='" + breed + "'";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var catReader = cmd.ExecuteReader();
                if (catReader.HasRows)
                {
                    catReader.Read();
                    cat = new Cat(Convert.ToString(catReader["Breed"]).Trim(),
                                         Convert.ToString(catReader["Country"]).Trim(),
                                         Convert.ToString(catReader["Origin"]).Trim(),
                                         Convert.ToString(catReader["Body Type"]).Trim(),
                                         Convert.ToString(catReader["Coat"]).Trim(),
                                         Convert.ToString(catReader["Pattern"]).Trim(),
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

        public void AddCat(Cat cat, string changes)
        {
            var conn = new SqlConnection(GetConnectionString());
            var sql = "INSERT INTO " + _table + " VALUES('" + cat.GetBreed().Trim() + "','" + cat.GetCountry().Trim() + "','" + cat.GetOrigin().Trim() + "','" + cat.GetBodyType().Trim() + "','" + cat.GetCoat().Trim() + "','" + cat.GetPattern().Trim() + "','" + cat.GetImage().Trim() + "','" + cat.GetInfo().Trim();

            if (_admin)
            {
                sql += "','" + changes;
            }
            sql += "')";

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
            var sql = "SELECT * FROM " + _table;

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
                                             Convert.ToString(catsReader["Origin"]).Trim(),
                                             Convert.ToString(catsReader["Body Type"]).Trim(),
                                             Convert.ToString(catsReader["Coat"]).Trim(),
                                             Convert.ToString(catsReader["Pattern"]).Trim(),
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
            var sql = "SELECT DISTINCT [" + specificationName + "] FROM " + _table;

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
                var msg = "GetListOfSpecification Sql Error: ";
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
            var sql = "SELECT [" + specificationName + "] FROM " + _table + " WHERE [Breed]='" + breed + "'";

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
                var msg = "GetBreedSpecification Sql Error: ";
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
            var sql = "UPDATE " + _table + " SET [" + specificationName + "]='" + specificationValue + "' WHERE [Breed]='" + breed + "'";
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                var msg = "AddtSpecificationToBreed Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        public LinkedList<Cat> FindBreedBySpecifications(string[] specifications)
        {
            var breedList = new LinkedList<Cat>();

            var conn = new SqlConnection(GetConnectionString());
            var sql = "SELECT [Breed], [Image] FROM " + _table + " WHERE [Body type]='" + specifications[0] + "' OR [Coat]='" + specifications[1] + "' OR [Pattern]='" + specifications[2] + "'";
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var breedAndImageReader = cmd.ExecuteReader();
                while (breedAndImageReader.Read())
                {
                    var cat = new Cat(Convert.ToString(breedAndImageReader["Breed"]).Trim(), Convert.ToString(breedAndImageReader["Image"]).Trim());
                    if (breedList.Count == 0)
                    {
                        breedList.AddFirst(cat);
                    }
                    else
                    {
                        breedList.AddAfter(breedList.Last, cat);
                    }
                }
            }
            catch (SqlException ex)
            {
                var msg = "FindBreedBySpecification Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
            return breedList;
        }

        public void DeleteCat(string breed)
        {
            var conn = new SqlConnection(GetConnectionString());
            var sql = "DELETE FROM " + _table + " WHERE [Breed]='" + breed + "'";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                var msg = "DeleteCat Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteCat(string breed, string specification, string value)
        {
            var conn = new SqlConnection(GetConnectionString());
            var sql = "DELETE FROM " + _table + " WHERE [Breed]='" + breed + "' AND [" + specification + "]='" + value + "'";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                var msg = "DeleteCat Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        public void AddChanges(string breed, string changes)
        {
            var conn = new SqlConnection(GetConnectionString());
            var sql = "UPDATE CatsAdmin SET [Changes]='" + changes + "' WHERE [Breed]='" + breed + "'";
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                var msg = "AddChanges Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }            
        }

        public void DeleteRow(int row)
        {
                        var conn = new SqlConnection(GetConnectionString());
            var sql =
                "WITH CTE AS ( (SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY Breed) as row FROM CatsAdmin ) a WHERE row > " + row + " and row <= " + (row+1) + ")) DELETE FROM CTE";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                var msg = "DeleteRow Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        public LinkedList<Cat> GetAllCatsWithChanges()
        {
            var catsList = new LinkedList<Cat>();

            var conn = new SqlConnection(GetConnectionString());
            const string sql = "SELECT * FROM CatsAdmin";

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
                                             Convert.ToString(catsReader["Origin"]).Trim(),
                                             Convert.ToString(catsReader["Body Type"]).Trim(),
                                             Convert.ToString(catsReader["Coat"]).Trim(),
                                             Convert.ToString(catsReader["Pattern"]).Trim(),
                                             Convert.ToString(catsReader["Image"]).Trim(),
                                             Convert.ToString(catsReader["Information"]).Trim(),
                                             Convert.ToString(catsReader["Changes"]).Trim());

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
                var msg = "GetAllCatsWithChanges Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
            return catsList;
        }
    }
}