using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayeKeyILS
{
    class DatabaseConnector
    {
        public List<long> GetPatronID()
        {
            List<long> patronIDs = new List<long>();

            using (var db = new ILSDBEntities())
            {
                patronIDs = (from ptrns in db.Patrons select ptrns.Id).ToList();
            }

            return patronIDs;
        }

        public List<string> GetPatronFirstName()
        {
            List<string> patronNames = new List<string>();

            using (var db = new ILSDBEntities())
            {
                patronNames = (from ptrns in db.Patrons select ptrns.patronFirstName).ToList();
            }

            return patronNames;
        }

        public List<string> GetPatronLastName()
        {
            List<string> patronLastNames = new List<string>();

            using (var db = new ILSDBEntities())
            {
                patronLastNames = (from ptrns in db.Patrons select ptrns.patronLastName).ToList();
            }

            return patronLastNames;
        }

        public List<string> GetPatronEmail()
        {
            List<string> patronEmail = new List<string>();

            using (var db = new ILSDBEntities())
            {
                patronEmail = (from ptrns in db.Patrons select ptrns.patronEmail).ToList();
            }

            return patronEmail;
        }

        public List<string> GetPatronPhone()
        {
            List<string> patronPhone = new List<string>();

            using (var db = new ILSDBEntities())
            {
                patronPhone = (from ptrns in db.Patrons select ptrns.patronPhone).ToList();
            }

            return patronPhone;
        }

        public List<Patron> GetFullPatronInfo()
        {
            List<long> id = new List<long>();
            List<string> fName = new List<string>();
            List<string> lName = new List<string>();
            List<string> email = new List<string>();
            List<string> phone = new List<string>();

            List<Patron> patron = new List<Patron>();

            id = GetPatronID();
            fName = GetPatronFirstName();
            lName = GetPatronLastName();
            email = GetPatronEmail();
            phone = GetPatronPhone();

            for (int i = 0; i < fName.Count(); i++)
            {
                patron.Add(new Patron { Id = id[i], patronFirstName = fName[i], patronLastName = lName[i], patronEmail = email[i], patronPhone = phone[i] });
            }

            return patron;
        }
        public partial class material
        {
            public string materialType { get; set; }
            public string materialName { get; set; }
        }

        public void Addmaterial(string materialType, string materialName)
        {
            using (var db = new MembersListEntities())
            {
                List<string> target = new List<string>();
                target = (from mems in db.members select mems.materialName).ToList();


                for (int i = 0; i < target.Count(); i++)
                {
                    if (target[i] == materialName)
                    {
                        string message = "Already Exist";
                        string title = "Attention";
                        MessageBox.Show(message, title);
                        return;
                    }
                }

                material newMember = new material
                {
                    // ID of every new object is one more than the ID of the last object in the table
                    materialName = materialName,
                    materialType = materialType
                };

                db.members.Add(newMember);
                db.SaveChanges();
                db.Dispose(); // I believe the "using" statement renders this redundant but hey, YouTube said so
            }

        }

        public void removeMaterial(string materialName)
        {
            using (var db = new MembersListEntities())
            {
                material m = db.members.First(i => i.materialName == materialName);
                db.members.Attach(m);
                db.members.Remove(m);
                db.SaveChanges();

            }

        }



    }
}





