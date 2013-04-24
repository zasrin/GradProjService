using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GradService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        //GetCommentStream
        public CommentStream getCommentStream(String API_Key, String Stream_ID)
        {
            Stream stream = new Stream();
            Comments comments = new Comments();
            Comment comment1 = new Comment();
            Comment comment2 = new Comment();
            CommentStream commentStream = new CommentStream();
            User user = getUser("42", System.Guid.NewGuid().ToString());

            comment1.ID = System.Guid.NewGuid().ToString();
            comment1.rating = 5;
            comment1.subject = "Comment 1";
            comment1.comment = "This is just a test comment. It is the first test comment of two";
            comment1.user = user;

            comment2.ID = System.Guid.NewGuid().ToString();
            comment2.rating = 3;
            comment2.subject = "Comment 2";
            comment2.comment = "This is just a test comment. It is the second test comment of two";
            comment2.user = user;

            comments.Add(comment1);
            comments.Add(comment2);

            stream.stream_ID = Stream_ID;
            stream.name = "Test Stream";
            stream.description = "This is just a test description for a test tream that is taking place in a test of the getCommentStream funtion";

            commentStream._stream = stream;
            commentStream.comments = comments;

            return commentStream;
        }

        //PostComment
        public CommentStream postComment(String API_Key, String Stream_ID, Comment comment)
        {
            //do db stuff
            CommentStream commentStream = getCommentStream(API_Key, Stream_ID);
            
            //exclude this from final since stream above will have new comment in it
            commentStream.comments.Add(comment);
            return commentStream;
        }

        //EditComment
        public CommentStream editComment(String API_Key, String Stream_ID, Comment comment)
        {
            //do db stuff here
            return postComment(API_Key, Stream_ID, comment);
        }

        //GetUserBio
        public User getUser(String API_Key, String uid)
        {
            //todo: db stuff to get user information
            User user = new User();
            user.email = "brad@email.com";
            user.firstName = "brad";
            user.lastName = "duerling";
            user.uid = uid;
            user.gender = "male";
            user.password = null;
            user.fbID = null;
            user.googID = null;

            return user;

        }

        //EditUserBio
        public User editUser(String API_Key, String User_ID, User user)
        {
            //do database stuff
            return user;
        }

        //CreateUser
        public User createUser(String API_Key, User user)
        {
            //do db stuff here
            if (!(string.IsNullOrEmpty(user.email) && string.IsNullOrEmpty(user.password) && !string.IsNullOrEmpty(user.uid)))
            {

                user.uid = System.Guid.NewGuid().ToString();
                user.password = null;
                //do some db stuff here
            }
            return user;
        }

        //GetUserComments
        public CommentStream getUserComments(String API_Key, String User_ID)
        {
            //do db stuff here
            return getCommentStream(API_Key, "42");
        }

        //CheckEmail
        public Boolean checkEmailAvail(String API_Key, String email)
        {
            if (email == "brad@email.com")
                return false;
            return true;
        }

        //Login
        public User login(String API_Key, User user)
        {
            if (!(string.IsNullOrEmpty(user.email) && string.IsNullOrEmpty(user.password) && !string.IsNullOrEmpty(user.uid)))
            {

                user.uid = System.Guid.NewGuid().ToString();
                user.password = null;
                //do some db stuff here
            }
            return user;
        }

        //DeleteComment
        public CommentStream deleteComment(String API_Key, String Stream_ID, String Comment_ID)
        {
            return getCommentStream(API_Key, Stream_ID);
        }

    }
}
