using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RatingServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string AddRatingRecord(string productid, string memberid, string comment, double rating);
        [OperationContract]
        Boolean DeleteRating(string pid,string mid);
        [OperationContract]
        Boolean UpdateRating(string productid, string memberid, string comment, double rating);
        [OperationContract]
        List<Review> SearchByMember(string memberid);
        [OperationContract]
        List<Review> SearchByProduct(string prdId);

        [OperationContract]
        List<Review> printReviews();
    }



    [DataContract]
    public class Review
    {
        // [DataMember]
        public int ReviewId { get; set; }
        [DataMember]
        public string ProductId { get; set; }
        [DataMember]
        public string MemberId { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public double rating { get; set; }

    }

}
