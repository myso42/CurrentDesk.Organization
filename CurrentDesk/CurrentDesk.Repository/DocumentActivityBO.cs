using System;
using System.Linq;
using System.Collections.Generic;
using CurrentDesk.DAL;
using CurrentDesk.Models;

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template at 10/5/2013 4:04:27 PM
//	   and this file should not get overridden 
//
//     Add your own data access methods.
// </auto-generated>
//------------------------------------------------------------------------------ 
	
namespace CurrentDesk.Repository.CurrentDesk
{   
	public class DocumentActivityBO
	{
		// Add your own data access methods here.  If you wish to
		// expose your public method to a WCF service, marked them with
		// the attribute [NCPublish], and another T4 template will generate your service contract

        /// <summary>
        /// This method inserts document activity details in db
        /// </summary>
        /// <param name="pkActivityID">pkActivityID</param>
        /// <param name="docID">docID</param>
        /// <param name="status">status</param>
        public void InsertDocumentActivityDetails(int pkActivityID, int docID, string status)
        {
            try
            {
                using (var unitOfWork = new EFUnitOfWork())
                {
                    var docActRepo =
                        new DocumentActivityRepository(new EFRepository<DocumentActivity>(), unitOfWork);

                    DocumentActivity newDocAct = new DocumentActivity();
                    newDocAct.FK_UserActivityID = pkActivityID;
                    newDocAct.FK_DocumentID = docID;
                    newDocAct.DocumentStatus = status;

                    docActRepo.Add(newDocAct);
                    docActRepo.Save();
                }
            }
            catch (Exception ex)
            {
                CommonErrorLogger.CommonErrorLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }
		
	}
}