
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GradService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //GetComment
        [WebGet(UriTemplate = "{API_Key}/Comments/{Stream_ID}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        CommentStream getCommentStream(String API_Key, String Stream_ID);

        //PostComment
        [WebInvoke(Method = "POST", UriTemplate = "{API_Key}/Comments/{Stream_ID}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        CommentStream postComment(String API_Key, String Stream_ID, Comment comment);

        //EditComment
        [WebInvoke(Method = "PUT", UriTemplate = "{API_Key}/Comments/{Stream_ID}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        CommentStream editComment(String API_Key, String Stream_ID, Comment comment);

        //GetUserBio
        [WebGet(UriTemplate = "{API_Key}/Users/{User_ID}/Bio", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        User getUser(String API_Key, String User_ID);

        //EditUserBio
        [WebInvoke(Method = "PUT", UriTemplate = "{API_Key}/Users/{User_ID}/Bio", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        User editUser(String API_Key, String User_ID, User user);

        //CreateUser
        [WebInvoke(Method = "POST", UriTemplate = "{API_Key}/Users/Register", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        User createUser(String API_Key, User user);

        //GetUserComments
        [WebGet(UriTemplate = "{API_Key}/Users/{User_ID}/Comments", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        CommentStream getUserComments(String API_Key, String User_ID);

        //CheckEmail
        [WebGet(UriTemplate = "{API_Key}/Users?email={email}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        Boolean checkEmailAvail(String API_Key, String email);

        //Login
        [WebInvoke(Method = "POST", UriTemplate = "{API_Key}/Users/Login", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        User login(String API_Key, User user);

        //DeleteComment
        [WebInvoke(Method = "DELETE", UriTemplate = "{API_Key}/Comments/{Stream_ID}/{Comment_ID}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        CommentStream deleteComment(String API_Key, String Stream_ID, String Comment_ID);

    }

    [DataContract]
    public class User
    {
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        public string uid { get; set; }
        [DataMember]
        public string gender { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string googID { get; set; }
        [DataMember]
        public string fbID { get; set; }
    }

    [DataContract]
    public class Comment
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string streamID { get; set; }
        [DataMember]
        public User user { get; set; }
        [DataMember]
        public string comment { get; set; }
        [DataMember]
        public string subject { get; set; }
        [DataMember]
        public int rating { get; set; }
    }

    [DataContract]
    public class Site
    {
        [DataMember]
        public string domain { get; set; }
        [DataMember]
        public string api_Key { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string db_ID { get; set; }
    }

    [DataContract]
    public class Stream
    {
        [DataMember]
        public string stream_ID { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
    }

    [DataContract]
    public class CommentStream
    {
        [DataMember]
        public Stream _stream { get; set; }
        [DataMember]
        public Comments comments { get; set; }
    }

    [CollectionDataContract]
    public class Comments : List<Comment>
    {
        public Comments() { }
        public Comments(List<Comment> comments) : base(comments) { }
    }
}
