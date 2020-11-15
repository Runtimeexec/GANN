using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Utilities;

namespace FileTransmitToUploadReceiver
{
    class Program
    {
        static async Task Main()
        {
            Program prog = new Program();

            //Update Start Time in DB
            using var cn = new SqlConnection() { ConnectionString = "Data Source = GANN; " + "Initial Catalog=gann;" + "User id=gann_user;" + "Password=[PASSWORD];" };
            //Get all Bitstring Files
            var directory = @"../../../../ONNX-Inference/Data/Evolved_Bitstring/Bitstrings/";
            var files = Directory.GetFiles(directory);
            cn.Open();

            foreach (string filePath in files)
            {
                // read data from file
                using var inputFile = new System.IO.StreamReader(filePath);
                string str = string.Empty;

                while ((str = inputFile.ReadLine()) != null)
                {
                    var byteArray = BitStringUtils.ConvertBitstring2ByteArray(str);
                    {
                        var dt = DateTime.UtcNow;
                        string statementStart = "UPDATE [gann].[dbo].[EvolvedFilesMeta] SET [StartTime] = @dt WHERE [Filename] = @fileName";
                        var cmd = new SqlCommand(statementStart, cn);
                        cmd.Parameters.Add("@dt", SqlDbType.DateTime);
                        cmd.Parameters.Add("@fileName", SqlDbType.NVarChar);
                        cmd.Parameters["@dt"].Value = dt;
                        cmd.Parameters["@fileName"].Value = Path.GetFileName(filePath);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        Thread.Sleep(1000);

                        //send bytes converted from Tinyints
                        var success = Convert.ToBoolean(await prog.UploadFile(filePath, byteArray));

                        Thread.Sleep(1000);

                        if (success == true)
                        {
                            //Update End Time to DB if response is true                                
                            var dt2 = DateTime.UtcNow;
                            string statementEnd = "UPDATE [gann].[dbo].[EvolvedFilesMeta] SET [EndTime] = @dt2 WHERE [Filename] = @fileName";
                            var cmd2 = new SqlCommand(statementEnd, cn);
                            cmd2.Parameters.Add("@dt2", SqlDbType.DateTime);
                            cmd2.Parameters.Add("@fileName", SqlDbType.NVarChar);
                            cmd2.Parameters["@dt2"].Value = dt2;
                            cmd2.Parameters["@fileName"].Value = Path.GetFileName(filePath);
                            cmd2.ExecuteNonQuery();
                            cmd2.Dispose();
                        }
                    }
                }
            }
        }

        public async Task<string> UploadFile(string filePath, byte[] file)
        {
            using var form = new MultipartFormDataContent();
            using var fileContent = new ByteArrayContent(file);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            form.Add(fileContent, "file", Path.GetFileName(filePath));
            form.Add(new StringContent("789"), "userId");
            form.Add(new StringContent("some comments"), "comment");
            form.Add(new StringContent("true"), "isPrimary");
            HttpClient httpClient = new HttpClient();

            //var response = await httpClient.PostAsync("http://localhost:59701/api/Upload/", form);
            var response = await httpClient.PostAsync("http://gann2:8081/api/Upload", form);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            //var result = JsonSerializer.Deserialize<FileUploadResult>(responseContent);
            //_logger.LogInformation("Uploading is complete.");

            return responseContent.ToString();
        }

        private class FileUploadResult
        {
            public string Guid { get; internal set; }
        }
    }
}
