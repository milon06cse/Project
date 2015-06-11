using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ClassLibrary
{
   public class ForumUser
    {
       private Guid id { get ;set; }
       private string name { get; set; }
       private enumUserType type { get; set; }
       private DateTime birthday  { get; set; }
       private string cellno { get; set; }
       private string nid { get; set; }
       private string address { get; set; }
       private string zipcode { get; set; }
       public ForumUser()
       {
           id =Guid.Empty;
           name =string.Empty;
           type =enumUserType.Default;
           birthday=DateTime.MinValue;
           cellno =string.Empty;
           nid  =string.Empty;
           address  =string.Empty;
           zipcode = string.Empty;
       }
       public Guid Id { get { return id; } set { id = value; } }
       public string Name { get { return name; } set { name = value; } }
       public enumUserType Type { get {return type ;} set {type=value ;} }
       public DateTime Birthday { get { return birthday;} set {birthday=value ;} }
       public string Cellno { get { return cellno;} set {cellno=value ;} }
       public string Nid { get { return nid;} set {nid=value ;} }
       public string Address { get {return address ;} set {address=value ;} }
       public string ZipCode { get { return zipcode;} set {zipcode=value ;} }

    }
}
