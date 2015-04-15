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
           // return repository.ShowAll();
            return new List<ForumSectionModel>();
        }
        internal ForumSectionModel ShowFirstOne()
        {
            ForumSectionRepository repository = new ForumSectionRepository();
            ForumSection Section= repository.ShowFirstSection();
            ForumSectionModel model = new ForumSectionModel();
            model.SectionName = Section.SectionName;
            model.DisplayOrder = Section.DisplayOrder;
            return model;
        }
    }
}