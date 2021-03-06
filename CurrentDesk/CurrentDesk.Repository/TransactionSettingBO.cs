using System;
using System.Linq;
using CurrentDesk.DAL;
using CurrentDesk.Models;
using System.Data.Objects;

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template at 24/6/2013 11:35:28 AM
//	   and this file should not get overridden 
//
//     Add your own data access methods.
// </auto-generated>
//------------------------------------------------------------------------------ 
	
namespace CurrentDesk.Repository.CurrentDesk
{   
	public class TransactionSettingBO
	{
		// Add your own data access methods here.  If you wish to
		// expose your public method to a WCF service, marked them with
		// the attribute [NCPublish], and another T4 template will generate your service contract

        /// <summary>
        /// This method adds or updates new transaction settings
        /// </summary>
        /// <param name="setting">setting</param>
        /// <returns></returns>
        public bool AddOrUpdateTransactionSetting(TransactionSetting setting)
        {
            try
            {
                using (var unitOfWork = new EFUnitOfWork())
                {
                    var transactionSettingRepo =
                        new TransactionSettingRepository(new EFRepository<TransactionSetting>(), unitOfWork);

                    ObjectSet<TransactionSetting> transactionSettingObjSet =
                        ((CurrentDeskClientsEntities)transactionSettingRepo.Repository.UnitOfWork.Context).TransactionSettings;

                    //Get present setting from db
                    var dbSetting = transactionSettingObjSet.Where(sett => sett.FK_AdminTransactionTypeID == setting.FK_AdminTransactionTypeID && sett.FK_OrganizationID == setting.FK_OrganizationID).FirstOrDefault();

                    //If settings present in db
                    if (dbSetting != null)
                    {
                        dbSetting.FK_CurrencyID = setting.FK_CurrencyID;
                        dbSetting.MinimumDepositAmount = setting.MinimumDepositAmount;
                        dbSetting.TransferFee = setting.TransferFee;
                        dbSetting.InternalTransferApprovalOptions = setting.InternalTransferApprovalOptions;
                        dbSetting.InternalTransferLimitedAmount = setting.InternalTransferLimitedAmount;
                        dbSetting.MarginRestriction = setting.MarginRestriction;
                        dbSetting.ConversionMarkupType = setting.ConversionMarkupType;
                        dbSetting.ConversionMarkupValue = setting.ConversionMarkupValue;
                    }
                    else
                    {
                        transactionSettingRepo.Add(setting);
                    }

                    //Save and return true
                    transactionSettingRepo.Save();
                    return true;
                }
            }
            catch (Exception ex)
            {
                CommonErrorLogger.CommonErrorLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        /// <summary>
        /// This method returns transaction setting details
        /// for a particular transaction type
        /// </summary>
        /// <param name="transactionType">transactionType</param>
        /// <param name="organizationID">organizationID</param>
        /// <returns></returns>
        public TransactionSetting GetTransactionSetting(int transactionType, int organizationID)
        {
            try
            {
                using (var unitOfWork = new EFUnitOfWork())
                {
                    var transactionSettingRepo =
                        new TransactionSettingRepository(new EFRepository<TransactionSetting>(), unitOfWork);

                    ObjectSet<TransactionSetting> transactionSettingObjSet =
                        ((CurrentDeskClientsEntities)transactionSettingRepo.Repository.UnitOfWork.Context).TransactionSettings;

                    return transactionSettingObjSet.Where(sett => sett.FK_AdminTransactionTypeID == transactionType && sett.FK_OrganizationID == organizationID).FirstOrDefault();
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