using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace QuintonPOS
{

    class clsCleanUps
    {

        static string iGarbagePath = clsSysFolder.itrashFilePath;
        static string cGarbagePath = clsSysFolder.ctrashFilePath;
        static string sGarbagePath = clsSysFolder.strashFilePath;
        static string[] garbageFileList;

        static List<string> finalList = new List<string>();


        /// <summary>
        /// GARBAGE COLLECTION ON PRODUCT IMAGES
        /// </summary>
        public static void addProductImageToGarbageList(string imageFileName)
        {
            try
            {
                File.Create(iGarbagePath + imageFileName + ".bin");
            }
            catch (Exception ex)
            {
             
              //MessageBox.Show("Could not add unwanted files to Garbage bin!","QPOS",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
          
   
        }


        /// <summary>
        /// GARBAGE COLLECTION ON CUSTOMER IMAGES
        /// </summary>
        public static void addCustImageToGarbageList(string imageFileName)
        {
            try
            {
                File.Create(cGarbagePath + imageFileName + ".bin");
            }
            catch (Exception ex)
            {

              // MessageBox.Show("Could not add unwanted files to Garbage bin!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        /// <summary>
        /// GARBAGE COLLECTION ON SUPPLIER IMAGES
        /// </summary>
        public static void addSupImageToGarbageList(string imageFileName)
        {
            try
            {
                File.Create(sGarbagePath + imageFileName + ".bin");
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Could not add unwanted files to Garbage bin!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        /// <summary>
        /// EMPTY ALL REGISTERED IMAGES IN THE TRASH FOLDER
        /// </summary>
        public static void emptyTrash()
        {
            emptyProductImages();
            emptyCustomerImages();
            emptySupplierImages();
        }

        /// <summary>
        /// RECORD COLLECTION ON PRODUCT IMAGES
        /// </summary>
        private static void emptyProductImages()
        {
            try
            {
                garbageFileList = Directory.GetFiles(iGarbagePath); //get all the trash file records with their directories and extensions


                for (int i = 0; i <= garbageFileList.Length - 1; i++)
                {
                    finalList.Add(Path.GetFileNameWithoutExtension(garbageFileList[i])); //get file record names only WITHOUT paths and extensions

                }

                for (int i = 0; i <= finalList.Count - 1; i++)
                {
                    File.Delete(clsSysFolder.ifilePath + finalList[i] + ".avt"); //Delete the unwanted images
                    File.Delete(iGarbagePath + finalList[i] + ".bin"); //Delete the unwanted file records
                }

            }
            catch (Exception ex)
            {
                //clsSystemTray.notifier("Could not empty trash at the moment, task rescheduled to next system launch!");

            }

            
        }


        /// <summary>
        /// RECORD COLLECTION ON CUSTOMER IMAGES
        /// </summary>
        private static void emptyCustomerImages()
        {
            try
            {
                garbageFileList = Directory.GetFiles(cGarbagePath); //get all the trash file records with their directories and extensions


                for (int i = 0; i <= garbageFileList.Length - 1; i++)
                {
                    finalList.Add(Path.GetFileNameWithoutExtension(garbageFileList[i])); //get file record names only WITHOUT paths and extensions

                }

                for (int i = 0; i <= finalList.Count - 1; i++)
                {
                    File.Delete(clsSysFolder.cfilePath + finalList[i] + ".avt"); //Delete the unwanted images
                    File.Delete(cGarbagePath + finalList[i] + ".bin"); //Delete the unwanted file records
                }

            }
            catch (Exception ex)
            {
           //     MessageBox.Show("Could not empty trash at the moment, task rescheduled to next system launch!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        /// <summary>
        /// RECORD COLLECTION ON SUPPLIER IMAGES
        /// </summary>
        private static void emptySupplierImages()
        {
            try
            {
                garbageFileList = Directory.GetFiles(sGarbagePath); //get all the trash file records with their directories and extensions


                for (int i = 0; i <= garbageFileList.Length - 1; i++)
                {
                    finalList.Add(Path.GetFileNameWithoutExtension(garbageFileList[i])); //get file record names only WITHOUT paths and extensions

                }

                for (int i = 0; i <= finalList.Count - 1; i++)
                {
                    File.Delete(clsSysFolder.sfilePath + finalList[i] + ".avt"); //Delete the unwanted images
                    File.Delete(sGarbagePath + finalList[i] + ".bin"); //Delete the unwanted file records
                }

            }
            catch (Exception ex)
            {
//MessageBox.Show("Could not empty trash at the moment, task rescheduled to next system launch!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

    }
}
