using System;
using System.IO;
using W2Open.Common.Game.v747;
using W2Open.Common.Utility;

namespace W2Open.DataServer
{
    public static class PlayerAccountCRUD
    {
        public enum EResult
        {
            NO_ERROR,
            /// <summary>
            /// The requested account does not exist in the database server.
            /// </summary>
            ACC_NOT_FOUND,
            /// <summary>
            /// A account save request failed.
            /// The caller must treat this error as a CRITICAL error. This possibily indicates a corrupted game state.
            /// </summary>
            ACC_NOT_SAVED,
            /// <summary>
            /// Some unknown error occour when processing the account.
            /// The caller must treat this error as a CRITICAL error, close all the interactions with the requesting player
            /// and save/log the error.
            /// </summary>
            UNKNOWN,
        }

        private static EResult ProcessSystemException(Exception e)
        {
            EResult result = EResult.UNKNOWN;

            if (e.InnerException is FileNotFoundException || e.InnerException is DirectoryNotFoundException)
            {
                result = EResult.ACC_NOT_FOUND;
            }

            return result;
        }

        public static EResult TryReadAccount(string login, string psw, out UPlayerAccount accFile)
        {
            EResult result = EResult.NO_ERROR;
            accFile = new UPlayerAccount();

            try
            {
                byte[] rawAcc = File.ReadAllBytes(string.Format("{0}/{1}/{2}.bin",
                       PersistencyBasics.DB_ROOT_PATH, login.Substring(0, 1).ToUpper(), login.ToUpper()));

                W2Marshal.GetStructure(rawAcc, 0, out accFile);
            }
            catch (Exception e)
            {
                result = ProcessSystemException(e);
            }

            return result;
        }

        public static EResult TrySaveAccount(UPlayerAccount acc)
        {
            EResult result = EResult.NO_ERROR;
            byte[] accBuffer = W2Marshal.GetBytes(acc);

            try
            {
                File.WriteAllBytes(string.Format("{0}/{1}/{2}.bin",
                        PersistencyBasics.DB_ROOT_PATH, acc.Login.Substring(0, 1).ToUpper(),
                        acc.Login.ToUpper()), accBuffer);
            }
            catch(Exception e)
            {
                result = ProcessSystemException(e);   
            }

            return result;
        }
    }
}