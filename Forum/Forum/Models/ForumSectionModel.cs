using Forum.ClassLibrary;
using Forum.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class ForumSectionModel
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public Guid Id { get; set; }
        //List<ForumThread> Threads = new List<ForumThread>();
        internal void Save()
        {
            ForumSection Section = new ForumSection();
            ForumSectionRepository repository = new ForumSectionRepository();
            Section.Id = Guid.NewGuid(); //repository.MaxColumnValue("Id", "ForumSection");
            Section.Name = Name;
            Section.DisplayOrder = DisplayOrder;
            repository.Add(Section);
        }
        internal List<ForumSectionModel> Show()
        {
            ForumSectionRepository repository = new ForumSectionRepository();
            List<ForumSectionModel> models = new List<ForumSectionModel>();
            foreach (ForumSection item in repository.ShowAll())
            {
                ForumSectionModel model = new ForumSectionModel();
                model.Name = item.Name;
                model.DisplayOrder = item.DisplayOrder;
                model.Id = item.Id;
                models.Add(model);
            }
            return models;

        }
        internal ForumSectionModel ShowFirstOne()
        {
            ForumSectionRepository repository = new ForumSectionRepository();
            ForumSection Section= repository.ShowFirstSection();
            ForumSectionModel model = new ForumSectionModel();
            model.Name = Section.Name;
            model.DisplayOrder = Section.DisplayOrder;
            model.Id = Section.Id;
            return model;
        }
    }
}