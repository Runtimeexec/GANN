using Microsoft.ML.Data;
using Microsoft.ML.OnnxRuntime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Utilities;

namespace ONNX_Inference
{
    class Program
    {
        static void Main()
        {
            var session = new InferenceSession(@"../../../Models/cntk-mlp15.onnx");

            var session1 = new InferenceSession(@"../../../Models/tf-mlp20.onnx");

            var inputMeta = session.InputMetadata;
            //var outputMeta = session.OutputMetadata;

            var input1Meta = session1.InputMetadata;
            //var output1Meta = session1.OutputMetadata;

            List<NamedOnnxValue> container = new List<NamedOnnxValue>();

            int[] dm = new int[] { 1, 1000 };

            //Previous runs with small amounts of data
            //var Data = LoadTENSORSFromFiles(@"../../../Data/Test_Bitstring/");
            //var Data = LoadTENSORSFromFiles(@"../../../Data/Test_Bitstring2/");
            
            var Data = LoadTENSORSFromFiles(@"../../../Data/Evolved_Bitstring/Bitstrings/");

            int x = 0;
            foreach (var fltArrList in Data.Tensors)
            {
                foreach (var fltArr in fltArrList.Value)
                {
                    float[] sourceData = fltArr;
                    string fileName = fltArrList.Key;
                    
                    Utilities.DatabaseUtils insertData = new Utilities.DatabaseUtils();
                    int tinyIntID = insertData.InsertFloatsIntoEvolvedTinyInts(fileName, sourceData);

                    foreach (var name in inputMeta.Keys)
                    {
                        container.Clear();
                        var tensor = new Microsoft.ML.OnnxRuntime.Tensors.DenseTensor<float>(fltArr, dm);
                        container.Add(NamedOnnxValue.CreateFromTensor<float>(name, tensor));

                        using (var results = session.Run(container))  // results is an IDisposableReadOnlyCollection<DisposableNamedOnnxValue> container
                        {

                            foreach (var r in results)
                            {

                                {
                                    //Console.WriteLine("Output for {0}", r.Name);
                                    StringBuilder s = new StringBuilder();
                                    var str = r.AsTensor<float>().GetArrayString();
                                    var str1 = str.Replace('{', ' ').Replace('}', ' ').Trim();
                                    var flt = float.Parse(str1);

                                    //if (flt*1000 > 4.0)
                                    {

                                        Console.WriteLine(x);
                                        Console.WriteLine(Path.GetFileName(fileName));
                                        Console.WriteLine(flt*10000);

                                        insertData.InsertOrUpdateEvolvedFilesMetaCNTK(tinyIntID, Path.GetFileName(fileName), flt*10000);
                                    }
                                    x++;
                                }
                            }
                        }

                        foreach (var name1 in input1Meta.Keys)
                        {
                            container.Clear();
                            var tensor1 = new Microsoft.ML.OnnxRuntime.Tensors.DenseTensor<float>(fltArr, dm);
                            container.Add(NamedOnnxValue.CreateFromTensor<float>(name1, tensor1));

                            using var results = session1.Run(container);
                            foreach (var r in results)
                            {

                                {
                                    //Console.WriteLine("Output for {0}", r.Name);
                                    StringBuilder s = new StringBuilder();
                                    var str = r.AsTensor<float>().GetArrayString();
                                    var str1 = str.Replace('{', ' ').Replace('}', ' ').Trim();
                                    var flt = float.Parse(str1);

                                    //if (flt*1000 > 4.0)
                                    {

                                        Console.WriteLine(x);
                                        Console.WriteLine(Path.GetFileName(fileName));
                                        Console.WriteLine(flt*100);

                                        insertData.InsertOrUpdateEvolvedFilesMetaTF(tinyIntID, Path.GetFileName(fileName), flt*100);
                                    }
                                    x++;
                                }
                            }
                        }
                    }
                }
            }

            static DataObject LoadTENSORSFromFiles(string directory)
            {
                var files = Directory.GetFiles(directory);
                DataObject obj = new DataObject
                {
                    Tensors = new Dictionary<string, List<float[]>>()
                };

                foreach (string filename in files)
                {
                    List<float[]> list = null;
                    // read data from file
                    using var inputFile = new System.IO.StreamReader(filename);
                    List<float[]> dataStr = new List<float[]>();

                    var x = 0;
                    string str = string.Empty;

                    while ((str = inputFile.ReadLine()) != null)
                    {
                        float[] ftArr = new float[1000];
                        var byteArray = BitStringUtils.ConvertBitstring2ByteArray(str);

                        for (int i = 0; i < byteArray.Length; i++)
                        {
                            float ft = byteArray[i];
                            ftArr[i] = ft;

                        }
                        dataStr.Add(ftArr);
                        x++;

                    }
                    list = new List<float[]>(dataStr); ;
                    obj.Tensors.Add(filename, list);

                }
                return obj;
            }
        }
    }

    public class DataObject
    {
        private string[] names;
        private Dictionary<string, List<float[]>> tensors;

        public string[] Names  // property
        {
            get { return names; }
            set { names = value; }
        }

        public Dictionary<string, List<float[]>> Tensors   // property
        {
            get { return tensors; }
            set { tensors = value; }
        }
    }
}