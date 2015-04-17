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
        public string SectionName { get; set; }
        public int DisplayOrder { get; set; }
        public int SectionId { get; set; }

        internal void Save()
        {
            ForumSection Section = new ForumSection();
            ForumSectionRepository repository = new ForumSectionRepository();
            Section.SectionId = repository.MaxColumnValue("SectionId", "ForumSection");
            Section.SectionName = SectionName;
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
                model.SectionName = item.SectionName;
                model.DisplayOrder = item.DisplayOrder;
                model.SectionId = item.SectionId;
                models.Add(model);
            }
            return models;

        }
        internal ForumSectionModel ShowFirstOne()
        {
            ForumSectionRepository repository = new ForumSectionRepository();
            ForumSection Section= repository.ShowFirstSection();
            ForumSectionModel model = new ForumSectionModel();
            model.SectionName = Section.SectionName;
            model.DisplayOrder = Section.DisplayOrder;
            model.SectionId = Section.SectionId;
            return model;
        }
    }
}