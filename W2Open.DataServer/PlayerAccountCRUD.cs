using System;
using System.IO;
using W2Open.Common;

namespace W2Open.DataServer
{
    /// <summary>
    /// Used for test-purpose only.
    /// </summary>
    [Obsolete]
    public class UPlayerAccountBinaryWrapper : IUnmanagedReader, IUnmanagedWriter
    {
        public CPlayerAccount PlayerAcc { get; set; }

        public UPlayerAccountBinaryWrapper(CPlayerAccount playerAcc)
        {
            PlayerAcc = playerAcc;
        }

        public int UnmanagedSize
        {
            get
            {
                return (
                    PlayerAcc.Login.UnmanagedSize +
                    PlayerAcc.Password.UnmanagedSize +
                    PlayerAcc.Cargo.UnmanagedSize
                    );
            }
        }

        public unsafe void ReadFromUnmanaged(byte* pointedBuffer)
        {
            PlayerAcc.Login.ReadFromUnmanaged(pointedBuffer);
            pointedBuffer += PlayerAcc.Login.UnmanagedSize;

            PlayerAcc.Password.ReadFromUnmanaged(pointedBuffer);
            pointedBuffer += PlayerAcc.Password.UnmanagedSize;

            PlayerAcc.Cargo.ReadFromUnmanaged(pointedBuffer);
            pointedBuffer += PlayerAcc.Cargo.UnmanagedSize;
        }

        public unsafe void WriteToUnmanaged(byte* pointedBuffer)
        {
            PlayerAcc.Login.WriteToUnmanaged(pointedBuffer);
            pointedBuffer += PlayerAcc.Login.UnmanagedSize;

            PlayerAcc.Password.WriteToUnmanaged(pointedBuffer);
            pointedBuffer += PlayerAcc.Password.UnmanagedSize;

            PlayerAcc.Cargo.WriteToUnmanaged(pointedBuffer);
            pointedBuffer += PlayerAcc.Cargo.UnmanagedSize;
        }
    }

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

        public static unsafe EResult TryRead(String accName, out CPlayerAccount accFile)
        {
            EResult err = EResult.NO_ERROR;
            accFile = null;

            try
            {
                byte[] rawAcc = File.ReadAllBytes(String.Format("{0}/{1}/{2}.bin",
                    PersistencyBasics.DB_ROOT_PATH, accName.Substring(0, 1).ToUpper(), accName.ToUpper()));

                UPlayerAccountBinaryWrapper accWrapper = new UPlayerAccountBinaryWrapper(new CPlayerAccount("", ""));
                
                fixed(byte* b = rawAcc)
                {
                    accWrapper.ReadFromUnmanaged(b);
                }

                accFile = accWrapper.PlayerAcc;
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

        public static unsafe EResult TrySaveAccount(CPlayerAccount acc)
        {
            UPlayerAccountBinaryWrapper accWrapper = new UPlayerAccountBinaryWrapper(acc);

            byte[] rawAcc = new byte[accWrapper.UnmanagedSize];

            fixed(byte* b = rawAcc)
            {
                accWrapper.WriteToUnmanaged(b);
            }

            File.WriteAllBytes(String.Format("{0}/{1}/{2}.bin",
                    PersistencyBasics.DB_ROOT_PATH, acc.Login.Value.Substring(0, 1).ToUpper(),
                    acc.Login.Value.ToUpper()), rawAcc);

            return EResult.NO_ERROR;
        }
    }
}