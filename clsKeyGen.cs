using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace QuintonPOS
{
    class clsKeyGen
    {
        private static string generateKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        /// <summary>
        /// The unique Invoice Number for Invoice Identification
        /// </summary>
        /// <returns>A Randomly Generated Code</returns>
        public static int InvoiceGen()
    {
        int result = 0;
        result = Convert.ToInt32(generateKey(4));

        return result;

    }


        /// <summary>
        /// The unique Product Code for Product identification
        /// </summary>
        /// <returns>A Randomly Generated Code</returns>
        public static String getFullItemCode()
        {
            String result;
            result = "It-" + generateKey(5);

           return result;
        }

        /// <summary>
        /// The unique Stock Code for Stock  identification
        /// </summary>
        /// <returns>A Randomly Generated Code</returns>
        public static String getFullSTCode()
        {
            String result;
            result = "St-" + generateKey(5);

            return result;
        }

        /// <summary>
        /// The unique User ID Number for User identification
        /// </summary>
        /// <returns>A Randomly Generated Code</returns>
        public static String getFullUSERCode()
        {
            String result;
            result = "U" + generateKey(5);

            return result;
        }

        /// <summary>
        /// The unique Customer Profile Picture Code for Image identification
        /// </summary>
        /// <returns>A Randomly Generated Code</returns>
        public static String getFullCACode()
        {
            String result;
            result = "cprp-" + generateKey(5);

            return result;
        }

        /// <summary>
        /// The unique Supplier Profile Picture Code for Image Identification
        /// </summary>
        /// <returns>A Randomly Generated Code</returns>
        public static String getFullSACode()
        {
            String result;
            result = "prp-" + generateKey(5);

            return result;
        }


        /// <summary>
        /// The unique Product Profile Picture for Image Identification
        /// </summary>
        /// <returns>A Randomly Generated Code</returns>
        public static String getFullITACode()
        {
            String result;
            result = "img-" + generateKey(5);

            return result;
        }

        /// <summary>
        /// The Customer ID for unique Customer Identification
        /// </summary>
        /// <returns>A Randomly Generated Code</returns>
        public static String getFullCustomerCode()
        {
            String result;
            result = "cid-" + generateKey(5);

            return result;
        }

        /// <summary>
        ///The Order ID for Unique Order Identification
        /// </summary>
        /// <returns>A Randomly Generated Code</returns>
        public static int createOrderCode()
        {
            int result = 0;
            result = Convert.ToInt32(generateKey(5));

            return result;
           
        }

        /// <summary>
        /// The Supplier ID for Unique Supplier Identification
        /// </summary>
        /// <returns>A Randomly Generated Code</returns>
        public static String getFullSupplierCode()
        {
            String result;
            result = "Sp-" + generateKey(5);

            return result;
        }

        /// <summary>
        /// The unique Receiving Code for Received Orders Identification 
        /// </summary>
        /// <returns>A Randomly Generated Code</returns>
        public static String getFullRECCode()
        {
            String result;
            result = "RC-" + generateKey(5);

            return result;
        }

        /// <summary>
        /// The Product Refference Code When Creating and Receiving Orders
        /// </summary>
        /// <returns>A Randomly Generated Code</returns>
        public static int RefferenceCode()
        {
            int result = 0;
            result = Convert.ToInt32(generateKey(4));

            return result;

        }

    }
}
