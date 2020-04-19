using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RatingServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string AddRatingRecord(string productid,string memberid,string comment,double rating)
        {
            string result;
            string conn = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=socratings;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd;
                string query = "Insert into Review(ProductId,MemberId,Comment,Rating) values(@ProductId,@MemberId,@Comment,@Rating)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", productid);
                cmd.Parameters.AddWithValue("@MemberId", memberid);
                cmd.Parameters.AddWithValue("@Comment",comment);
                cmd.Parameters.AddWithValue("@Rating", rating);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                result = "Success";
            }
            catch (FaultException fex)
            {
                Console.WriteLine(fex);
                result = "Error";
            }

            return result;
        }

        public bool DeleteRating(string pid,string mid)
        {
            try
            {
                string conn = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=socratings;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd;
                string Query = "Delete from Review where ProductId=@ProductId and MemberId = @MemberId";
                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ProductId", pid);
                cmd.Parameters.AddWithValue("@MemberId", mid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //return true;
            }
            catch (FaultException fex)
            {
                Console.WriteLine(fex);
                return false;
            }
            return true;
        }


        public List<Review> printReviews()
        {
            List<Review> r = new List<Review>();
            try
            {
                string conn = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=socratings;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd;
                string query = "Select ProductId,MemberId,Comment,Rating from Review";
                cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Review rv = new Review();
                    rv.ProductId = rdr["ProductId"].ToString();
                    rv.MemberId = rdr["MemberId"].ToString();
                    rv.Comment = rdr["Comment"].ToString();
                    rv.rating = Double.Parse(rdr["rating"].ToString());
                    r.Add(rv);
                }

            }
            catch (FaultException fex)
            {
                Console.WriteLine(fex);
                return null;
            }
            return r;
        }

        public List<Review> SearchByMember(string memberid)
        {
            List<Review> r = new List<Review>();
            try
            {
                string conn = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=socratings;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd;
                string query = "Select ProductId,MemberId,Comment,Rating from Review where MemberId = @MemberId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MemberId", memberid);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Review rv = new Review();
                    rv.ProductId = rdr["ProductId"].ToString();
                    rv.MemberId = rdr["MemberId"].ToString();
                    rv.Comment = rdr["Comment"].ToString();
                    rv.rating = Double.Parse(rdr["rating"].ToString());
                    r.Add(rv);
                }

            }
            catch (FaultException fex)
            {
                Console.WriteLine(fex);
                return null;
            }
            return r;
        }

        public List<Review> SearchByProduct(string prdId)
        {
            List<Review> r = new List<Review>();
            try
            {
                string conn = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=socratings;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd;
                string query = "Select ProductId,MemberId,Comment,Rating from Review where ProductId = @ProductId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", prdId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Review rv = new Review();
                    rv.ProductId = rdr["ProductId"].ToString();
                    rv.MemberId = rdr["MemberId"].ToString();
                    rv.Comment = rdr["Comment"].ToString();
                    rv.rating = Double.Parse(rdr["rating"].ToString());
                    r.Add(rv);
                }

            }
            catch (FaultException fex)
            {
                Console.WriteLine(fex);
                return null;
            }
            return r;
        }

        public bool UpdateRating(string productid, string memberid, string comment, double rating)
        {
            string conn = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=socratings;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd;
                string query = "Update Review set Comment= @Comment, rating = @Rating where ProductId = @ProductId  and MemberId = @MemberId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", productid);
                cmd.Parameters.AddWithValue("@MemberId", memberid);
                cmd.Parameters.AddWithValue("@Comment", comment);
                cmd.Parameters.AddWithValue("@Rating", rating);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (FaultException fex)
            {
                Console.WriteLine(fex);
                return false;
            }

            return true;
        }

    }
}
