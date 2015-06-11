using Forum.ClassLibrary;
using Forum.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class ForumUserModel
    {
        //here id  is not req
        public string Name { get; set; }
        public enumUserType Type { get; set; }
        public DateTime Birthday { get; set; }
        public string Cellno { get; set; }
        public string Nid { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        internal bool Save(ForumUserModel model)
        {
            ForumUser user = new ForumUser();
            user.Name = model.Name;
            user.Nid = model.Nid;
            UserRepository repository = new UserRepository();
            return repository.Add(user);
        }

        internal List<ForumUserModel>  ShowAllUser() //suggested type System.Web.Mvc.IView
        {
            List<ForumUserModel> models = new List<ForumUserModel>();
//            List<ForumUser> users = new List<ForumUser>();
            UserRepository repository = new UserRepository();
            foreach (ForumUser item in repository.ShowAllUser())
            {
                ForumUserModel model = new ForumUserModel();
                model.Name = item.Name;
                model.Nid = item.Nid;
                models.Add(model);
            }
            return models;
        }
    }
}