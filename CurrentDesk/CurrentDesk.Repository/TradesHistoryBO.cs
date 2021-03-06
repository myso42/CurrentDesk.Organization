using System;
using System.Linq;
using System.Collections.Generic;
using CurrentDesk.DAL;
using CurrentDesk.Models;
using System.Data.EntityClient;

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template at 5/20/2013 5:59:32 PM
//	   and this file should not get overridden 
//
//     Add your own data access methods.
// </auto-generated>
//------------------------------------------------------------------------------ 

namespace CurrentDesk.Repository.CurrentDesk
{
    public class TradesHistoryBO
    {
        // Add your own data access methods here.  If you wish to
        // expose your public method to a WCF service, marked them with
        // the attribute [NCPublish], and another T4 template will generate your service contract

        /// <summary>
        /// Get CloseTime of LastTrade
        /// </summary>
        /// <returns></returns>
        public long? GetMaxCloseTime()
        {
            long? maxCloseTime = 0L;

            try
            {

                using (var unitOfWork = new EFUnitOfWork())
                {

                    var context = (CurrentDeskClientsEntities)unitOfWork.Context;

                    maxCloseTime = context.TradesHistories.Max(s => s.CloseTime);

                }
            }
            catch (Exception ex)
            {
                maxCloseTime = -1;
                CommonErrorLogger.CommonErrorLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }


            return maxCloseTime;

        }

        /// <summary>
        /// Get Connection string
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            string strConnection = string.Empty;
            try
            {

                using (var unitOfWork = new EFUnitOfWork())
                {
                    var context = (CurrentDeskClientsEntities)unitOfWork.Context;
                    strConnection = ((EntityConnection)context.Connection).StoreConnection.ConnectionString;
                }
            }
            catch (Exception ex)
            {
                CommonErrorLogger.CommonErrorLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return strConnection;
        }

        /// <summary>
        /// Get all the closed trades from the available asset manager.
        /// </summary>
        /// <param name="loginIDList">loginIDList</param>
        /// <param name="lastProcessedID">lastProcessedID</param>
        /// <returns></returns>
        public List<TradesHistory> GetAssetManagerClosedTrades(List<int> loginIDList, int lastProcessedID)
        {
            try
            {
                using (var unitOfWork = new EFUnitOfWork())
                {
                    var tradeHistoryRepo =
                        new TradesHistoryRepository(new EFRepository<TradesHistory>(), unitOfWork);

                    return ((CurrentDeskClientsEntities)tradeHistoryRepo.Repository.UnitOfWork.Context).TradesHistories.
                        Where(x => loginIDList.Contains((int)x.Login) && x.PK_TradeID > lastProcessedID && (x.Cmd == 0 || x.Cmd == 1)).
                        OrderBy(x => x.PK_TradeID).ToList();
                }

            }
            catch (Exception exceptionMessage)
            {
                CommonErrorLogger.CommonErrorLog(exceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return null;
            }

        }

        /// <summary>
        /// This Function will get all the Trades dependng 
        /// upon the platform login 
        /// </summary>
        /// <param name="platformLoginList">platformLoginList</param>
        /// <param name="fromDate">fromDate</param>
        /// <param name="toDate">toDate</param>
        /// <returns>TradesHistory List</returns>
        public List<TradesHistory> GetAllCurrencyClosedTradesByPlatformLogin(List<int?> platformLoginList, long fromDate, long toDate)
        {
            try
            {
                List<int> currencyCodeList = new List<int>() { 0, 2 };
                using (var unitOfWork = new EFUnitOfWork())
                {
                    var tradeHistoryRepo =
                        new TradesHistoryRepository(new EFRepository<TradesHistory>(), unitOfWork);

                    var tradeHistoryList = ((CurrentDeskClientsEntities)tradeHistoryRepo.Repository.UnitOfWork.Context).TradesHistories.
                        Where(x => platformLoginList.Contains(x.Login) && 
                            x.Timestamp > fromDate && 
                            x.Timestamp < toDate && x.MarginMode != null).ToList();

                    tradeHistoryList = tradeHistoryList.Where(x => currencyCodeList.Contains((int)x.MarginMode)).ToList();

                    return tradeHistoryList;
                }

            }
            catch (Exception exceptionMessage)
            {
                CommonErrorLogger.CommonErrorLog(exceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        /// <summary>
        /// This Function will get all the Trades dependng 
        /// upon the platform login 
        /// </summary>
        /// <param name="platformLoginList">platformLoginList</param>
        /// <param name="fromDate">fromDate</param>
        /// <param name="toDate">toDate</param>
        /// <returns>TradesHistory List</returns>
        public List<TradesHistory> GetAllCurrencyCFDTradesByPlatformLogin(List<int?> platformLoginList, long fromDate, long toDate)
        {
            try
            {
                List<int> cfdCodeList = new List<int>() { 1, 3, 4 };
                using (var unitOfWork = new EFUnitOfWork())
                {
                    var tradeHistoryRepo =
                        new TradesHistoryRepository(new EFRepository<TradesHistory>(), unitOfWork);

                    var tradeHistoryList = ((CurrentDeskClientsEntities)tradeHistoryRepo.Repository.UnitOfWork.Context).TradesHistories.
                        Where(x => platformLoginList.Contains(x.Login) &&
                            x.Timestamp > fromDate &&
                            x.Timestamp < toDate && x.MarginMode != null).ToList();

                    tradeHistoryList = tradeHistoryList.Where(x => cfdCodeList.Contains((int)x.MarginMode)).ToList();

                    return tradeHistoryList;
                }

            }
            catch (Exception exceptionMessage)
            {
                CommonErrorLogger.CommonErrorLog(exceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }
    }
}