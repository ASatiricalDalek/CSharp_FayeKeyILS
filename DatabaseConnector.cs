using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FayeKeyILS
{
    class DatabaseConnector
    {
        /// <summary>
        /// Get list of all patron id's in patron db table
        /// </summary>
        /// <returns></returns>
        public List<long> GetPatronID()
        {
            List<long> patronIDs = new List<long>();

            using (var db = new ILSDBEntities())
            {
                patronIDs = (from ptrns in db.Patrons select ptrns.Id).ToList();
            }

            return patronIDs;
        }
        /// <summary>
        /// Get list of all patron first names in patron db table
        /// </summary>
        /// <returns></returns>
        public List<string> GetPatronFirstName()
        {
            List<string> patronNames = new List<string>();

            using (var db = new ILSDBEntities())
            {
                patronNames = (from ptrns in db.Patrons select ptrns.patronFirstName).ToList();
            }

            return patronNames;
        }
        /// <summary>
        /// Get list of all last names in patron db table
        /// </summary>
        /// <returns></returns>
        public List<string> GetPatronLastName()
        {
            List<string> patronLastNames = new List<string>();

            using (var db = new ILSDBEntities())
            {
                patronLastNames = (from ptrns in db.Patrons select ptrns.patronLastName).ToList();
            }

            return patronLastNames;
        }
        /// <summary>
        /// Get list of all emails in patron db table
        /// </summary>
        /// <returns></returns>
        public List<string> GetPatronEmail()
        {
            List<string> patronEmail = new List<string>();

            using (var db = new ILSDBEntities())
            {
                patronEmail = (from ptrns in db.Patrons select ptrns.patronEmail).ToList();
            }

            return patronEmail;
        }
        /// <summary>
        /// Get list of all phone numbers in patron db table
        /// </summary>
        /// <returns></returns>
        public List<string> GetPatronPhone()
        {
            List<string> patronPhone = new List<string>();

            using (var db = new ILSDBEntities())
            {
                patronPhone = (from ptrns in db.Patrons select ptrns.patronPhone).ToList();
            }

            return patronPhone;
        }
        /// <summary>
        /// Get list of all patron info in patron db table
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Updates Patron information
        /// </summary>
        /// <param name="pId">Given patron id</param>
        /// <param name="fname">Updated patron first name</param>
        /// <param name="lname">Updated patron last name</param>
        /// <param name="email">Updated patron email</param>
        /// <param name="phone">Updated patron phone number</param>
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
        /// <summary>
        /// Gets full information about the material associated with the given material id
        /// </summary>
        /// <param name="materialID">Id of the material which information is requested</param>
        /// <returns></returns>
        public List<Material> GetFullMaterialRecord(long materialID)
        {
            List<Material> fullMaterial = new List<Material>();

            using (var db = new ILSDBEntities())
            {
                fullMaterial = db.Materials.ToList();
            }

            return fullMaterial;
        }
        /// <summary>
        /// Gets Integer value of loan length on material associated with given material id
        /// </summary>
        /// <param name="materialID">Id of the material which information is requested</param>
        /// <returns></returns>
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
        /// <summary>
        /// Renews the checkout of the material associated with the given materialid
        /// </summary>
        /// <param name="mId">Id of the material whose checkout should be renewed</param>
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
        /// <summary>
        /// Returns list of all materials in materials db
        /// </summary>
        /// <returns></returns>
        public List<Material> GetFullMatInfo()
        {
            List<Material> allMat = new List<Material>();

            using (var db = new ILSDBEntities())
            {
                allMat = db.Materials.ToList();
            }

            return allMat;
        }
        /// <summary>
        /// returns list of all material id's in material db
        /// </summary>
        /// <returns></returns>
        public List<long> GetMatID()
        {
            List<long> matIDs = new List<long>();

            using (var db = new ILSDBEntities())
            {
                matIDs = (from mat in db.Materials select mat.Id).ToList();
            }

            return matIDs;
        }
        /// <summary>
        /// gets material type of all materials in material db
        /// </summary>
        /// <returns></returns>
        public List<string> GetMatType()
        {
            List<string> matType = new List<string>();

            using (var db = new ILSDBEntities())
            {
                matType = (from mat in db.LoanLengths select mat.MaterialType).ToList();
            }

            return matType;
        }
        /// <summary>
        /// Generates a new, unique, sequential material ID
        /// </summary>
        /// <returns>Unique material ID of type long</returns>
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
        /// <summary>
        /// gets the correct loan length from the LoanLengths table depending on which material type is queried
        /// </summary>
        /// <param name="type">Material Type which the loan length is needed</param>
        /// <returns></returns>
        public long getMatLoanLength(string type)
        {
            using (var db = new ILSDBEntities())
            {
                LoanLength l = db.LoanLengths.First(c => c.MaterialType == type);
                return l.LoanLength1;
            }
        }
        /// <summary>
        /// Adds a material to the material tb
        /// </summary>
        /// <param name="mtype">The type of material to be added</param>
        /// <param name="mname">The name of the material to be added</param>
        public void addMat(string mtype, string mname)
        {
            using (var db = new ILSDBEntities())
            {
                Material newMat = new Material
                {
                    materialType = mtype,
                    materialName = mname,
                    materialLoanLength = getMatLoanLength(mtype), //gets the loan length associated to the given material type
                    Id = generateMatId() //generates unique material id
                };
                db.Materials.Add(newMat);
                db.SaveChanges();
                db.Dispose();
            }
        }
        /// <summary>
        /// Removes material with given id from material db
        /// </summary>
        /// <param name="mId"></param>
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
        /// <summary>
        /// updates material with given id in material db
        /// </summary>
        /// <param name="mId">Material Id that is to be updated</param>
        /// <param name="mname">Material Name to updated to</param>
        /// <param name="mtype">Material type to update to</param>
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

            

