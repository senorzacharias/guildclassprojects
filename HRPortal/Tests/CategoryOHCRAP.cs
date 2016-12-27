using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class CategoryOHCRAP
    {
        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;
using System.IO;

namespace Data
    {
        public class FilePolicyRepository : IPolicyRepository
        {
            /// <summary>
            /// DataContractJSONSerializor ser = new (typeof(List<Policy>));
            /// object read = ser.ReadObject(stream)
            /// cast    poilicies = read as List<Policy>
            /// ser.WriteOjbect(stream, policies)   
            /// </summary>
            //using(FileStream stream  new FileStream(_filepath FileMode.Create, FileAccess.Write//write is giving access to write, same for read
            public string FILE_PATH = @"C: \Users\apprentice\Desktop\Repos\bitbucket\zach-robinson-individual-work\FlooringMastery.CLI\SystemIO\";
            private string _filePath;



            public FilePolicyRepository(string filepath)
            {
                _filePath = filepath;


            }

            public void Add(Policy policy)
            {
                Policy catchPolicy = new Policy();//sensible?functional?
                List<Policy> allPolicies = GetAll();
                var existsCategory = allPolicies.FirstOrDefault(c => c.PolicyName == policy.PolicyName);//try to use


                if (File.Exists(_filePath))
                {
                    policy.PolicyNumber = allPolicies.Count + 1;


                }
                else
                {
                    policy.PolicyNumber = 1;
                    using (StreamWriter sw = new StreamWriter(_filePath))
                    {
                        sw.WriteLine("PolicyNumber,PolicyName,PolicyContent,CategoryId");
                    }
                }



                using (StreamWriter sw = new StreamWriter(_filePath, true))
                {

                    string line = CreateOrderFormat(policy);

                    sw.WriteLine(line);
                }

                allPolicies.Add(policy);
            }

            public void Delete(int policyNumber)
            {
                List<Policy> loadedPolicies = GetAll();
                var selectedPolicy = loadedPolicies.FirstOrDefault(i => i.PolicyNumber == policyNumber);
                loadedPolicies.Remove(selectedPolicy);

                CreateOrderFile(loadedPolicies);
            }

            public Policy Get(int policyNumber)//no need
            {
                throw new NotImplementedException();
            }

            public List<Policy> GetAll()
            {
                List<Policy> allPolicies = new List<Policy>();

                //if (File.Exists(_filePath))
                //{

                using (StreamReader sr = new StreamReader(_filePath))
                {
                    sr.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Policy newPolicy = new Policy();
                        string[] columns = line.Split(new[] { ",/," }, StringSplitOptions.None);
                        int parse;
                        int.TryParse(columns[0], out parse);
                        newPolicy.PolicyNumber = parse;
                        newPolicy.PolicyName = columns[1];
                        newPolicy.PolicyContent = columns[2];
                        int parseId;
                        int.TryParse(columns[3], out parseId);
                        newPolicy.CategoryId = parseId;

                        allPolicies.Add(newPolicy);
                    }
                    //}
                }
                return allPolicies;
            }

            public void CreateOrderFile(List<Policy> policies)
            {
                if (File.Exists(_filePath))
                    File.Delete(_filePath);

                using (StreamWriter sw = new StreamWriter(_filePath))
                {
                    sw.WriteLine("PolicyNumber,PolicyName,PolicyContent,CategoryId");

                    foreach (var policy in policies)
                    {
                        sw.WriteLine(CreateOrderFormat(policy));
                    }
                }
            }

            public string CreateOrderFormat(Policy policy)
            {
                return string.Format($"{policy.PolicyNumber},/,{policy.PolicyName},/,{policy.PolicyContent},/,{policy.CategoryId}");

            }
        }
    }

}
}
