using System;
using System.IO;
using W2Open.Common.GameStructure;
using W2Open.Common.Utility;

namespace W2Open.DataServer
{
    public static class AccountCRUD
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

        public static EResult TryRead(String accName, out MAccountFile? accFile)
        {
            EResult err = EResult.NO_ERROR;
            accFile = null;
            
            try
            {
                byte[] rawAcc = File.ReadAllBytes(String.Format("{0}/{1}/{2}.bin",
                    PersistencyBasics.DB_ROOT_PATH, accName.Substring(0, 1).ToUpper(), accName.ToUpper()));

                accFile = W2Marshal.GetStructure<MAccountFile>(rawAcc);
            }
            catch(FileNotFoundException)
            {
                err = EResult.ACC_NOT_FOUND;
            }
            catch(DirectoryNotFoundException)
            {
                err = EResult.ACC_NOT_FOUND;
            }
            catch(Exception)
            {
                err = EResult.UNKNOWN;
            }

            return err;
        }

        public static EResult TrySaveAccount(ref MAccountFile acc)
        {
            var err = EResult.NO_ERROR;

            try
            {
                byte[] accBytes = W2Marshal.GetBytes(acc);

                File.WriteAllBytes(String.Format("{0}/{1}/{2}.bin",
                    PersistencyBasics.DB_ROOT_PATH, acc.Info.LoginInfo.AccName.Substring(0, 1).ToUpper(),
                    acc.Info.LoginInfo.AccName), accBytes);
            }
            catch(DirectoryNotFoundException)
            {
                err = EResult.ACC_NOT_SAVED;
            }
            catch(Exception)
            {
                err = EResult.UNKNOWN;
            }

            return err;
        }
    }
}