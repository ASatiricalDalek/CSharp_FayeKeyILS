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
            List<Patron> allPatrons = new List<Patron>();

            using (var db = new ILSDBEntities())
            {
                allPatrons = db.Patrons.ToList();
            }

            return allPatrons;
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
            using (var db = new ILSDBEntities())
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
            using (var db = new ILSDBEntities())
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

        /// <summary>
        /// Generates a new, unique, sequential patron ID
        /// </summary>
        /// <returns>Unique patron ID of type long</returns>
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

        /// <summary>
        /// Performs a checkout by updating the checkout table with the patron ID, Material ID, return date, and checkout date
        /// Also adds the patron ID to the material's entry on the material table as a foreign key
        /// </summary>
        /// <param name="mId">Material ID to uniquely identify the material</param>
        /// <param name="pId">Patron ID to uniquely identify the patron</param>
        public void checkoutMaterial(long mId, long pId)
        {
            using (var db = new ILSDBEntities())
            {
                DateTime currentDate, returnDate;
                string currentMaterialType;
                // Queries must be converted to lists, even if the query will only return one value
                // Load the currently selected material into a variable
                List<Material> currentMaterial = db.Materials.Where(i => i.Id == mId).ToList();
                currentMaterialType = currentMaterial[0].materialType;
                // Look up and load the entry for this material type's loan length
                List<LoanLength> loanLengthEntry = db.LoanLengths.Where(l => l.MaterialType == currentMaterialType).ToList();

                List<Checkout> allCheckouts = new List<Checkout>();
                currentDate = DateTime.Now;
                // Since ID is the primary key, there will only ever be one entry in the list
                returnDate = currentDate.AddDays(loanLengthEntry[0].LoanLength1);

                Checkout currentCheckout = new Checkout
                {
                    materialID = mId,
                    patronLibraryID = pId,
                    returnDate = returnDate.ToString("MM/dd/yyyy"),
                    checkoutDate = currentDate.ToString("MM/dd/yyyy")
                };
                // Add the checkout to the checkout table
                db.Checkouts.Add(currentCheckout);
                // Associate the patron checking out ID with the material record
                currentMaterial[0].patronLibraryID = pId;
                // Save changes
                db.SaveChanges();
                db.Dispose();
            }
        }

        /// <summary>
        /// Gets the entire checkout table
        /// </summary>
        /// <returns>List of all checkouts</returns>
        public List<Checkout> GetFullCheckoutInfo()
        {
            List<Checkout> allCheckouts = new List<Checkout>();

            using (var db = new ILSDBEntities())
            {
                allCheckouts = db.Checkouts.ToList();
            }

            return allCheckouts;
        }

        public List<Material> GetPatronCheckouts(long pId)
        {
            List<Material> patronItems = new List<Material>();

            using (var db = new ILSDBEntities())
            {
                patronItems = db.Materials.Where(c => c.patronLibraryID == pId).ToList();
            }

            return patronItems;
        }

        /// <summary>
        /// Returns a materials checkout record including it's checkout and return dates.
        /// </summary>
        /// <param name="matID">ID of the material</param>
        /// <returns>List of that material's checkout information</returns>
        public List<Checkout> GetCheckoutRecord(long matID)
        {
            List<Checkout> checkoutRecord = new List<Checkout>();

            using (var db = new ILSDBEntities())
            {
                checkoutRecord = db.Checkouts.Where(r => r.materialID == matID).ToList();
            }

            return checkoutRecord;
        }

        public List<Material> GetFullMaterialRecord(long materialID)
        {
            List<Material> fullMaterial = new List<Material>();

            using (var db = new ILSDBEntities())
            {
                fullMaterial = db.Materials.ToList();
            }

            return fullMaterial;
        }

        public int GetLoanLength(long materialID)
        {
            Material mat = new Material();
            using (var db = new ILSDBEntities())
            {
                mat = db.Materials.First(i => i.Id == materialID);
            }

            return Convert.ToInt32(mat.materialLoanLength);
        }

        /// <summary>
        /// Returns an item by removing it from the checkout table and stripping the patron ID from the materials table
        /// </summary>
        /// <param name="mId">Material ID that uniquely identifies the material you want to return</param>
        public void Return(long mId)
        {
            List<Checkout> allCheckouts = GetFullCheckoutInfo();
            long pId;

            if (allCheckouts.Any(i => i.materialID == mId) == true)
            {
                using (var db = new ILSDBEntities())
                {
                    // Remove entry from checkout table
                    Checkout chk = db.Checkouts.First(c => c.materialID == mId);
                    pId = chk.patronLibraryID;
                    db.Checkouts.Attach(chk);
                    db.Checkouts.Remove(chk);

                    // Remove library ID from field 
                    Material mat = db.Materials.First(m => m.patronLibraryID == pId);
                    mat.patronLibraryID = null;

                    db.SaveChanges();
                }
            }
        }

        public void Renew(long mId)
        {
            using (var db = new ILSDBEntities())
            {
                Checkout currentOut = db.Checkouts.First(i => i.materialID == mId);
                DateTime currentReturn, newReturn;
                int length = GetLoanLength(mId);

                currentReturn = DateTime.ParseExact(currentOut.returnDate, "MM/dd/yyyy", null);
                newReturn = currentReturn.AddDays(length);

                currentOut.returnDate = newReturn.ToString("MM/dd/yyyy");
                db.SaveChanges();

            }
        }

        public List<Material> GetFullMatInfo()
        {
            List<Material> allMat = new List<Material>();

            using (var db = new ILSDBEntities())
            {
                allMat = db.Materials.ToList();
            }

            return allMat;
        }

        public List<long> GetMatID()
        {
            List<long> matIDs = new List<long>();

            using (var db = new ILSDBEntities())
            {
                matIDs = (from mat in db.Materials select mat.Id).ToList();
            }

            return matIDs;
        }

        public List<string> GetMatType()
        {
            List<string> matType = new List<string>();

            using (var db = new ILSDBEntities())
            {
                matType = (from mat in db.LoanLengths select mat.MaterialType).ToList();
            }

            return matType;
        }

        private long generateMatId()
        {
            // Count+1 only works as long as members aren't deleted from the list, which they are in this application
            // This method will ensure that the new ID is always one greater than the highest ID currently in the database, whatever that may be

            List<Material> allMat = new List<Material>();
            List<long> allIDs = new List<long>();
            long newid;

            allMat = GetFullMatInfo();

            foreach (Material mat in allMat)
            {
                allIDs.Add(mat.Id);
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
        public long getMatLoanLength(string type)
        {
            using (var db = new ILSDBEntities())
            {
                LoanLength l = db.LoanLengths.First(c => c.MaterialType == type);
                return l.LoanLength1;
            }
        }

        public void addMat(string mtype, string mname)
        {
            using (var db = new ILSDBEntities())
            {
                Material newMat = new Material
                {
                    materialType = mtype,
                    materialName = mname,
                    materialLoanLength = getMatLoanLength(mtype),
                    Id = generateMatId()
                };
                db.Materials.Add(newMat);
                db.SaveChanges();
                db.Dispose();
            }
        }

        public void removeMat(long mId)
        {
            using (var db = new ILSDBEntities())
            {
                Material r = db.Materials.First(i => i.Id == mId);
                db.Materials.Attach(r);
                db.Materials.Remove(r);
                db.SaveChanges();
                db.Dispose();
            }
        }

        public void updateMaterial(long mId, string mname, string mtype)
        {
            using (var db = new ILSDBEntities())
            {
                Material m = db.Materials.First(i => i.Id == mId);
                m.materialName = mname;
                m.materialType = mtype;
                m.materialLoanLength = getMatLoanLength(mtype);
                db.SaveChanges();
                db.Dispose();
            }
        }
    }
}

            

