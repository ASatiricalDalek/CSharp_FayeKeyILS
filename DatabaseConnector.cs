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
        /// <summary>
        /// Add a patron
        /// </summary>
        /// <param name="fname">Patron First Name</param>
        /// <param name="lname">Patron Last Name</param>
        /// <param name="email">Patron Email</param>
        /// <param name="phone">Patron Phone Number</param>
        public void addPatron(string fname, string lname, string email, string phone)
        {
            using (var db = new ILSDBEntities())
            {
                Patron newPatron = new Patron
                {
                    patronFirstName = fname,
                    patronLastName = lname,
                    patronEmail = email,
                    patronPhone = phone,
                    Id = generatePatronId()
                };
                db.Patrons.Add(newPatron);
                db.SaveChanges();
                db.Dispose();
            }
        }
        /// <summary>
        /// Removes selected patron
        /// </summary>
        /// <param name="pId">Selected patron id</param>
        public void removePatron(long pId)
        {
            using(var db = new ILSDBEntities())
            {
                Patron r = db.Patrons.First(i => i.Id == pId);
                db.Patrons.Attach(r);
                db.Patrons.Remove(r);
                db.SaveChanges();
                db.Dispose();
            }
            
        }
        
        public void updatePatron(long pId, string fname, string lname, string email, string phone)
        {
            using(var db = new ILSDBEntities())
            {
                Patron u = db.Patrons.First(i => i.Id == pId);
                u.patronFirstName = fname;
                u.patronLastName = lname;
                u.patronEmail = email;
                u.patronPhone = phone;
                db.SaveChanges();
                db.Dispose();
            }
        }

        private long generatePatronId()
        {
            // Count+1 only works as long as members aren't deleted from the list, which they are in this application
            // This method will ensure that the new ID is always one greater than the highest ID currently in the database, whatever that may be

            List<Patron> allPatron = new List<Patron>();
            List<long> allIDs = new List<long>();
            long newid;

            allPatron = GetFullPatronInfo();

            foreach (Patron pat in allPatron)
            {
                allIDs.Add(pat.Id);
            }
            if (allIDs.Count > 0)
            {
                newid = allIDs.Max() + 1;
            }
            else
            {
                // If the database is empty, the ID will start at 1
                newid = 1;
            }


            return newid;
        }
    }
}


            

