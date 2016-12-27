
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;


namespace Data
{
    public class PolicyRepository : IPolicyRepository
    {
        private static List<Policy> _policies;


        static PolicyRepository()
        {

            _policies = new List<Policy>();

            Policy policy1 = new Policy
            {
                PolicyNumber = 1,
                PolicyName = "CanineConundrum",
                PolicyContent = "I like bringing my puppy to work.",
                CategoryId = 1
            };


            Policy policy2 = new Policy
            {
                PolicyNumber = 2,
                PolicyName = "Platonic",
                PolicyContent = "I enjoy bringing coworkers flowers for no reason at all.",
                CategoryId = 1
            };

            Policy policy3 = new Policy
            {
                PolicyNumber = 3,
                PolicyName = "Absenteeism",
                PolicyContent = "Sometimes I don't leave my bed.",
                CategoryId = 2
            };

            Policy policy4 = new Policy
            {
                PolicyNumber = 4,
                PolicyName = "KneeHighFourthOfJuly",
                PolicyContent = "Bringing back converse and knee high socks.",
                CategoryId = 2
            };

            Policy policy5 = new Policy
            {
                PolicyNumber = 5,
                PolicyName = "ShortSkirtLongJacket",
                PolicyContent = "I like someone that can cut through red tape.",
                CategoryId = 3
            };

            Policy policy6 = new Policy
            {
                PolicyNumber = 6,
                PolicyName = "Existentialism",
                PolicyContent = "HDT loves talking about ice.",
                CategoryId = 3
            };

            Policy policy7 = new Policy
            {
                PolicyNumber = 7,
                PolicyName = "LostGeneration",
                PolicyContent = "Pamplona in the summertime.",
                CategoryId = 4
            };

            Policy policy8 = new Policy
            {
                PolicyNumber = 8,
                PolicyName = "SKipToMyLou",
                PolicyContent = "Please walk through the hallways.",
                CategoryId = 4
            };
        

            _policies.Add(policy1);
            _policies.Add(policy2);
            _policies.Add(policy3);
            _policies.Add(policy4);
            _policies.Add(policy5);
            _policies.Add(policy6);
            _policies.Add(policy7);
            _policies.Add(policy8);
        }

        public List<Policy> GetAll()
        {
            return _policies;
        }

        public Policy Get(int policyNumber)
        {
            return _policies.FirstOrDefault(c => c.PolicyNumber == policyNumber);
        }

        public void Add(Policy policy)
        {

            policy.PolicyNumber = _policies.Max(c => c.PolicyNumber) + 1;

            _policies.Add(policy);
        }

        public void Delete(int policyNumber)
        {
            _policies.RemoveAll(c => c.PolicyNumber == policyNumber);
        }

    }
}
