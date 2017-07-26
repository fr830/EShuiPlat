using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EShuiPlat.Core
{
    public static class FileHelper
    {
        public static string basepath = AppContext.BaseDirectory;
        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="strFromPath"></param>
        /// <param name="strToPath"></param>
        public static void CopyFolder(string strFromPath, string strToPath)
        {
            //如果源文件夹不存在，则创建
            if (!Directory.Exists(strFromPath))
            {
                Directory.CreateDirectory(strFromPath);
            }
            //取得要拷贝的文件夹名
            string strFolderName = strFromPath.Substring(strFromPath.LastIndexOf("\\") + 1, strFromPath.Length - strFromPath.LastIndexOf("\\") - 1);

            //如果目标文件夹中没有源文件夹则在目标文件夹中创建源文件夹
            if (!Directory.Exists(strToPath + "\\" + strFolderName))
            {
                Directory.CreateDirectory(strToPath + "\\" + strFolderName);
            }
            //创建数组保存源文件夹下的文件名
            string[] strFiles = Directory.GetFiles(strFromPath);

            //循环拷贝文件
            for (int i = 0; i < strFiles.Length; i++)
            {
                //取得拷贝的文件名，只取文件名，地址截掉。
                string strFileName = strFiles[i].Substring(strFiles[i].LastIndexOf("\\") + 1, strFiles[i].Length - strFiles[i].LastIndexOf("\\") - 1);
                //开始拷贝文件,true表示覆盖同名文件
                File.Copy(strFiles[i], strToPath + "\\" + strFolderName + "\\" + strFileName, true);
            }

            //创建DirectoryInfo实例
            DirectoryInfo dirInfo = new DirectoryInfo(strFromPath);
            //取得源文件夹下的所有子文件夹名称
            DirectoryInfo[] ZiPath = dirInfo.GetDirectories();
            for (int j = 0; j < ZiPath.Length; j++)
            {
                //获取所有子文件夹名
                string strZiPath = strFromPath + "\\" + ZiPath[j].ToString();
                //把得到的子文件夹当成新的源文件夹，从头开始新一轮的拷贝
                CopyFolder(strZiPath, strToPath + "\\" + strFolderName);
            }
        }


        /// <summary>
        /// 删除文件夹下所的信息
        /// </summary>
        /// <param name="dir"></param>
        public static void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir)) //如果存在这个文件夹删除之 
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                        File.Delete(d); //直接删除其中的文件 
                    else
                        DeleteFolder(d); //递归删除子文件夹 
                }
                Directory.Delete(dir); //删除已空文件夹 

            }

        }

        /// <summary>
        /// 读取文本文件
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string ReadFromTxtFile(string filepath)
        {
            string content = "";
            if (filepath != "")
            {
                StreamReader fs = File.OpenText(filepath);

                content = fs.ReadToEnd().ToString();
                fs.Dispose();



            }
            return content;
        }
        /// <summary>
        /// 写文件,不带日期
        /// </summary>
        /// <param name="savePath"></param>
        /// <param name="txtStr"></param>
        public static void Write(string savePath, string txtStr)
        {
            FileStream fs = new FileStream(savePath, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(txtStr);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Dispose();
            fs.Dispose();
        }
        /// <summary>
        /// 写文件，自动加入日期和空行
        /// </summary>
        /// <param name="savePath"></param>
        /// <param name="txtStr"></param>
        public static void WriteLog(string savePath, string txtStr)
        {
            FileStream fs = new FileStream(savePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.WriteLine(DateTime.Now.ToString());
            sw.Write(txtStr);
            sw.WriteLine();
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Dispose();
            fs.Dispose();
        }
        /// <summary>
        /// 把任意对象信息以ＸＭＬ格式写入日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="savePath"></param>
        /// <param name="model"></param>
        public static void WriteLog<T>(string savePath, T model)
        {
            FileStream fs = new FileStream(savePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            //开始写入
            sw.WriteLine(DateTime.Now.ToString());
            sw.Write(model.GetPropertieInfo().ToXml());
            sw.WriteLine();
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Dispose();
            fs.Dispose();
        }

        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="filepath"></param>
        public static void DeleteFile(string filepath)
        {
            if (File.Exists(filepath))
                File.Delete(filepath);
        }

        /// <summary>
        /// 建文件
        /// </summary>
        /// <param name="filename"></param>
        public static void CreateFile(string filename)
        {
            using (File.Create(filename)) ;
        }

        /// <summary>
        /// 建文件夹
        /// </summary>
        /// <param name="foldername"></param>
        public static void CreateFolder(string foldername)
        {
            Directory.CreateDirectory(foldername);
        }
        /// <summary>
        /// 获取文件夹下所有文件
        /// </summary>
        /// <param name="foldername"></param>
        /// <returns></returns>

        public static List<string> GetFileList(string foldername)
        {
            List<string> lists = new List<string>();
            DirectoryInfo theFolder = new DirectoryInfo(foldername);
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in dirInfo)
            {
                FileInfo[] fileInfo = NextFolder.GetFiles();
                foreach (FileInfo NextFile in fileInfo)  //遍历文件
                    lists.Add(NextFile.Name);
            }

            return lists;
        }

        /// <summary>
        /// 获取所有文件列表
        /// </summary>
        /// <param name="foldername"></param>
        /// <returns></returns>
        public static List<string> GetAllFileList(string foldername)
        {
            List<string> lists = new List<string>();
            string[] files = Directory.GetFiles(foldername, "*", SearchOption.AllDirectories);

            lists.AddRange(files);
            return lists;
        }





    }
}
